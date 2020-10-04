using AuthServer.Infrastructure.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Infrastructure.Common.Events
{
    class UserProfileUpdatedEvent : DomainEvent
    {
        public UserProfileUpdatedEvent(UserProfile item)
        {
            Item = item;
        }

        public UserProfile Item { get; set; }
    }
}
