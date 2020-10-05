using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGroup.Domain.Entities
{
    public class ChannelMember
    {
        public int ChannelId { get; set; }
        public Channel Channel { get; set; }

        public Guid MemberId { get; set; }
        public Member Member { get; set; }
    }

}
