using OilyTools.Core.DomainEvents;

namespace OilyTools.Core.Interfaces.DomainEvents.Dispatchers
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}
