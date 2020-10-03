using AuthServer.Infrastructure.Common.Events;
using AuthServer.Infrastructure.Common.Interfaces;
using AuthServer.Infrastructure.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthServer.Infrastructure.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IApplicationDbContext _context;

        public UserProfileService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateProfile(UserProfile profile)
        {
            var entity = new UserProfile
            {
                FullName = profile.FullName,
                Bio = profile.Bio,
                Photo = profile.Photo
            };

            entity.DomainEvents.Add(new UserProfileCreatedEvent(entity));
            _context.UserProfile.Add(entity);

            await _context.SaveChangesAsync(new CancellationToken());

            return entity.Id;
        }

        public Task<UserProfile> GetProfile(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateProfile(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
