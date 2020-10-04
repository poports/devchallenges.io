using AuthServer.Infrastructure.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AuthServer.Infrastructure.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<UserProfile> UserProfile { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
