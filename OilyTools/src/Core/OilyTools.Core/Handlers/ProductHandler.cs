using Microsoft.Extensions.Logging;
using OilyTools.Core.DomainEvents;
using OilyTools.Core.Entities;
using OilyTools.Core.Persistence;

namespace OilyTools.Core.Handlers
{
    public class ProductHandler : 
        IHandle<ProductCreatedEvent>,
        IHandle<ProductPriceChangedEvent>
    {
        private readonly OilyToolsDbContext _context;
        private readonly ILogger _logger;

        public ProductHandler(OilyToolsDbContext context, ILogger<ProductHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Handle(ProductPriceChangedEvent domainEvent)
        {
            _logger.LogInformation($"ProductPriceChangeEvent handled.");

            _context.HistoricalPrices.Add(new HistoricalPrice
            {
                ProductId = domainEvent.ProductId,
                Price = domainEvent.NewPrice,
                StartDate = domainEvent.DateOccurred
            });
        }

        public void Handle(ProductCreatedEvent domainEvent)
        {
            _logger.LogInformation($"ProductCreatedEvent handled.");

            domainEvent.Product.HistoricalPrices.Add(new HistoricalPrice
            {
                Price = domainEvent.Product.CurrentPrice,
                StartDate = domainEvent.DateOccurred
            });
        }
    }
}
