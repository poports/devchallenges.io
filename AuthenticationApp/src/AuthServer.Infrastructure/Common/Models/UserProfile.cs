using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using  AuthServer.Infrastructure.Common;

namespace AuthServer.Infrastructure.Common.Models
{
    public class UserProfile : IHasDomainEvent
    {
        public Guid Id{ get; set; }
        public string  UserId { get; set; }
        public string  FullName { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }

        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
