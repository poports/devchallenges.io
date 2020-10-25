using ChatGroup.Domain.Common;
using System;

namespace ChatGroup.Domain.Entities
{
    public class ChannelChat : AuditableEntity
    {
        public Guid Id { get; set; }
        public int Channeld { get; set; }
        public Guid MemberId { get; set; }
        public string Mesage { get; set; }

        public Channel Channel { get; set; }
        public Member Member { get; set; }

    }
}
