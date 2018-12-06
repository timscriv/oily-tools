namespace Products.Core.DomainEvents
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
