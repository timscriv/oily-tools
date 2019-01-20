using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Products.Core.Common.Interfaces.Repositories;
using Products.Infrastructure.EntityFramework.Contexts;
using Products.Infrastructure.EntityFramework.Repositories;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EntityFrameworkServiceCollectionExtensions
    {

        public static IServiceCollection AddEntityFrameworkSqliteSuite(this IServiceCollection services, string connectionString, Action<SqliteDbContextOptionsBuilder> sqliteOptionsAction = null)
        {
            services.AddDbContext<ProductsContext>(options => options.UseSqlite(connectionString, sqliteOptionsAction));

            services.AddEntityFrameworkSuite();

            return services;
        }

        public static IServiceCollection AddEntityFrameworkSuite(this IServiceCollection services)
        {
            services.TryAddScoped<IProductReadOnlyRepository, ProductCachedRepository>();
            services.TryAddScoped<ProductRepository>();
            services.TryAddScoped<IProductRepository, ProductRepository>();
            services.TryAddScoped<IHistoricalPriceRepository, HistoricalPriceRepository>();

            return services;
        }
    }
}
