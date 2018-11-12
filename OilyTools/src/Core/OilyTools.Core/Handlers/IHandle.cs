using OilyTools.Core.DomainEvents;

namespace OilyTools.Core.Handlers
{
    public interface IHandle<T> where T: BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}
