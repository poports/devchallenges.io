using System;
using System.Collections.Generic;

namespace AuthServer.Infrastructure.Common
{
    public abstract class DomainEvent
    {
        public interface IHasDomainEvent
        {
            public List<DomainEvent> DomainEvents { get; set; }
        }

        protected DomainEvent()
        {
            DateOccurred = DateTimeOffset.UtcNow;
        }

        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
