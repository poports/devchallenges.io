
using Microsoft.AspNetCore.Identity;

namespace AuthServer.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Bio { get; set; }
        public string FullName { get; set; }
        public byte[] Photo { get; set; }
    }
}
