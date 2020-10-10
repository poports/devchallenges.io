using AuthServer.Infrastructure.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthServer.Infrastructure.Common.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfile> GetProfile(string userId);

        Task<Guid> UpdateProfile(UserProfile profile);
        Task<Guid> CreateProfile(UserProfile profile);
    }
}
