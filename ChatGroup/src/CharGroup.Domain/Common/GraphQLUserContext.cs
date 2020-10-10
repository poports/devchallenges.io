using System.Collections.Generic;
using System.Security.Claims;

namespace ChatGroup.Domain.Common
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
