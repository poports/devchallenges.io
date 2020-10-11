using AuthServer.Infrastructure.Common.Interfaces;
using AuthServer.Infrastructure.Identity;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Infrastructure.Services
{
    public class IdentityClaimsProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserProfileService _profileService;

        public IdentityClaimsProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IUserProfileService profileService)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
            _profileService = profileService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            var principal = await _claimsFactory.CreateAsync(user);
            var profile = await _profileService.GetProfile(sub);

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
            claims.Add(new Claim(JwtClaimTypes.GivenName, profile.FullName));
            claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email ?? ""));

            // note: to dynamically add roles (ie. for users other than consumers - simply look them up by sub id            
            claims.Add(new Claim(ClaimTypes.Role, principal.Claims.First(c => c.Type == "role").Value)); // need this for role-based authorization - https://stackoverflow.com/questions/40844310/role-based-authorization-with-identityserver4

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
