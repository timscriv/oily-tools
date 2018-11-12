using OilyTools.Core.DomainEvents;
using System.Collections.Generic;

namespace OilyTools.Core.Entities
{
    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
