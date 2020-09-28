using AuthServer.Infrastructure.Common.Models;
using AuthServer.Infrastructure.Identity;
using System.Threading.Tasks;

namespace AuthServer.Infrastructure.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<ApplicationUser> GetUserAsync(string userId);
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<Result> DeleteUserAsync(ApplicationUser user);
    }
}
