using AuthServer.Infrastructure.Common.Events;
using AuthServer.Infrastructure.Common.Exceptions;
using AuthServer.Infrastructure.Common.Interfaces;
using AuthServer.Infrastructure.Common.Models;
using System;
using System.Linq;
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
                UserId = profile.UserId,
                FullName = profile.FullName,
                Bio = profile.Bio,
                Photo = profile.Photo
            };

            entity.DomainEvents.Add(new UserProfileCreatedEvent(entity));
            _context.UserProfile.Add(entity);

            await _context.SaveChangesAsync(new CancellationToken());

            return entity.Id;
        }

        public UserProfile GetProfile(string userId)
        {
            var entity = _context.UserProfile.Single(x => x.UserId == userId);
                                        
            if (entity == null)
            {
                throw new NotFoundException(nameof(UserProfile), userId);
            }
            
            return entity;
        }

        public async Task<Guid> UpdateProfile(UserProfile profile)
        {
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
