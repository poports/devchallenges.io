using AuthServer.Infrastructure.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Infrastructure.Common.Events
{
    public class UserProfileCreatedEvent : DomainEvent
    {
        public UserProfileCreatedEvent(UserProfile item)
        {
            Item = item;
        }

        public UserProfile Item { get; set; }
    }
}
