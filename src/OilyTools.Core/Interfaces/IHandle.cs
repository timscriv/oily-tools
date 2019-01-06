using OilyTools.Core.DomainEvents;

namespace OilyTools.Core.Interfaces
{
    public interface IHandle<T> where T: BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}
