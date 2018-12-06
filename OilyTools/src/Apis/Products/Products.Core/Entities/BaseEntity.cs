using Products.Core.DomainEvents;
using System.Collections.Generic;

namespace Products.Core.Entities
{
    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
