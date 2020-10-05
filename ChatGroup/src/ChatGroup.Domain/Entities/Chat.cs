using ChatGroup.Domain.Common;
using System;

namespace ChatGroup.Domain.Entities
{
    public class Chat : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Message { get; set; }
    }
}
