using OilyTools.Core.Entities;

namespace OilyTools.Core.DomainEvents
{
    public class ProductCreatedEvent: BaseDomainEvent
    {
        public ProductCreatedEvent(Product product) {
            Product = product;
        }

        public Product Product { get; }
    }
}
