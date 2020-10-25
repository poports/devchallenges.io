using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGroup.Domain.Entities
{
    public class ChannelMember
    {
        public int Id { get; set; }
        public Guid MemberId { get; set; }
    }
}
