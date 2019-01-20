using OilyTools.Core.DomainEvents;
using System.Collections.Generic;

namespace Products.Core.Common.Entities
{
    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
