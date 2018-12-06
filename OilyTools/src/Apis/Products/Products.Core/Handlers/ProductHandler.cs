﻿using Microsoft.Extensions.Logging;
using Products.Core.DomainEvents;
using Products.Core.Entities;
using Products.Core.Repositories;

namespace Products.Core.Handlers
{
    public class ProductHandler : 
        IHandle<ProductCreatedEvent>,
        IHandle<ProductPriceChangedEvent>
    {
        private readonly IHistoricalPriceRepository _historicalPriceRepository;
        private readonly ILogger _logger;

        public ProductHandler(IHistoricalPriceRepository historicalPriceRepository, ILogger<ProductHandler> logger)
        {
            _historicalPriceRepository = historicalPriceRepository;
            _logger = logger;
        }

        public void Handle(ProductPriceChangedEvent domainEvent)
        {
            _logger.LogInformation($"ProductPriceChangeEvent handled.");

           //_context.HistoricalPrices.Add(new HistoricalPrice
           //{
           //    ProductId = domainEvent.ProductId,
           //    Price = domainEvent.NewPrice,
           //    StartDate = domainEvent.DateOccurred
           //});
        }

        public void Handle(ProductCreatedEvent domainEvent)
        {
            _logger.LogInformation($"ProductCreatedEvent handled.");

            //domainEvent.Product.HistoricalPrices.Add(new HistoricalPrice
            //{
            //    Price = domainEvent.Product.CurrentPrice,
            //    StartDate = domainEvent.DateOccurred
            //});
        }
    }
}
