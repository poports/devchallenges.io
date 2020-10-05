using System.Collections.Generic;

namespace ChatGroup.Domain.Entities
{
    public class Channel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Member> Members { get; set; }

    }
}
