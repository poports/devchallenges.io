using System.Threading;
using System.Threading.Tasks;

namespace AuthServer.Infrastructure.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
