using AuthServer.Infrastructure.Common.Events;
using AuthServer.Infrastructure.Common.Exceptions;
using AuthServer.Infrastructure.Common.Interfaces;
using AuthServer.Infrastructure.Common.Models;
using AuthServer.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace AuthServer.Infrastructure.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfileService(IApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<Guid> CreateProfile(UserProfile profile)
        {
            var user = await _userManager.FindByIdAsync(profile.UserId);
            await _userManager.AddClaimAsync(user, new Claim("fullName", profile.FullName ?? string.Empty));


            var entity = new UserProfile
            {
                UserId = profile.UserId,
                FullName = user.Email.Substring(0, user.Email.IndexOf('@')),
                Bio = profile.Bio,
                Photo = profile.Photo
            };

            entity.DomainEvents.Add(new UserProfileCreatedEvent(entity));
            _context.UserProfile.Add(entity);

            await _context.SaveChangesAsync(new CancellationToken());

            return entity.Id;
        }

        public async Task<UserProfile> GetProfile(string userId)
        {
            var entity = await _context.UserProfile.SingleAsync(x => x.UserId == userId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserProfile), userId);
            }
            
            return entity;
        }

        public async Task<Guid> UpdateProfile(UserProfile profile)
        {
            var user = await _userManager.FindByIdAsync(profile.UserId);
            var claims = await _userManager.GetClaimsAsync(user);
            await _userManager.ReplaceClaimAsync(user, claims?.FirstOrDefault(x => x.Type.Equals("fullName", StringComparison.OrdinalIgnoreCase)), new Claim("fullName", profile.FullName ?? string.Empty));

            var entity = _context.UserProfile.Single(x => x.UserId == profile.UserId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserProfile), profile.Id);
            }
            
            entity.Bio = profile.Bio;
            entity.Photo = profile.Photo ?? entity.Photo; //don't touch if null
            entity.FullName = profile.FullName;

            await _context.SaveChangesAsync(new CancellationToken());
            return entity.Id;

        }
    }
}
