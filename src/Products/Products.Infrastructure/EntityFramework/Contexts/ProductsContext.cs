using Microsoft.EntityFrameworkCore;
using OilyTools.Core.Interfaces.DomainEvents.Dispatchers;
using Products.Core.EntityFramework.Contexts.Configurations;
using Products.Core.Common.Entities;
using System.Linq;

namespace Products.Infrastructure.EntityFramework.Contexts
{
    public class ProductsContext: DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ProductsContext(
            DbContextOptions<ProductsContext> options,
            IDomainEventDispatcher dispatcher)
                    : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<HistoricalPrice> HistoricalPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new HistoricalPriceConfiguration());
        }

        public override int SaveChanges()
        {
            // Right BEFORE committing data (EF SaveChanges) into the DB. This makes
            // a single transaction including side effects from the domain event
            // handlers that are using the same DbContext with Scope lifetime
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

            // After this line runs, all the changes (from the Command Handler and Domain
            // event handlers) performed through the DbContext will be committed
            return base.SaveChanges();
        }
    }
}
