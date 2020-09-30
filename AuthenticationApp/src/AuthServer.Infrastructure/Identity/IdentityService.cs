using AuthServer.Infrastructure.Common.Interfaces;
using AuthServer.Infrastructure.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace AuthServer.Infrastructure.Identity 
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }
        public async Task<ApplicationUser> GetUserAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, IEnumerable<Claim> claims)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimsAsync(user, claims);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user) {
            var result = await _userManager.GetClaimsAsync(user);

            return result;
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<Result> AddClaimAsync(ApplicationUser user, Claim claim)
        {
            var result = await _userManager.AddClaimAsync(user, claim);

            return result.ToApplicationResult();
        }



    }
}
