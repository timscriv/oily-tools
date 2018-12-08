using OilyTools.Core.DomainEvents;
using Products.Core.Entities;

namespace Products.Core.DomainEvents
{
    public class ProductCreatedEvent: BaseDomainEvent
    {
        public ProductCreatedEvent(Product product) {
            Product = product;
        }

        public Product Product { get; }
    }
}
