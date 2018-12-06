namespace Products.Core.DomainEvents.Dispatchers
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}
