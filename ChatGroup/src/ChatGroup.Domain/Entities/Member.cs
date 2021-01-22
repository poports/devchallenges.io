using System;
using System.Collections.Generic;

namespace ChatGroup.Domain.Entities
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Channel> Channels { get; set; }
    }
}
