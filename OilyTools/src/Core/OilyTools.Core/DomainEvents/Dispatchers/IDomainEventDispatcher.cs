namespace OilyTools.Core.DomainEvents.Dispatchers
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}
