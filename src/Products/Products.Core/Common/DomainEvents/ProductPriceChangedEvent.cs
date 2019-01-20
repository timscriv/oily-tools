using OilyTools.Core.DomainEvents;

namespace Products.Core.Common.DomainEvents
{
    public class ProductPriceChangedEvent: BaseDomainEvent
    {
        public ProductPriceChangedEvent(int productId, decimal newPrice)
        {
            ProductId = productId;
            NewPrice = newPrice;
        }

        public int ProductId{ get; }
        public decimal NewPrice { get; }
    }
}
