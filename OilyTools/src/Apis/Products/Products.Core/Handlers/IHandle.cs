using Products.Core.DomainEvents;

namespace Products.Core.Handlers
{
    public interface IHandle<T> where T: BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}
