using CharGroup.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharGroup.Domain.Entities
{
    public class Channel : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
