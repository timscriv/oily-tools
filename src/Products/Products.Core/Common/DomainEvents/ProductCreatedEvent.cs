using OilyTools.Core.DomainEvents;
using Products.Core.Common.Entities;

namespace Products.Core.Common.DomainEvents
{
    public class ProductCreatedEvent: BaseDomainEvent
    {
        public ProductCreatedEvent(Product product) {
            Product = product;
        }

        public Product Product { get; }
    }
}
