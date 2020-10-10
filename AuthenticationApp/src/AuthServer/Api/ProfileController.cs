using AuthServer.Infrastructure.Common.Interfaces;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AuthServer.Api
{

    [Authorize(AuthenticationSchemes = IdentityServerConstants.LocalApi.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserProfileService _profileService;
        public ProfileController(IIdentityService identityService, IUserProfileService profileService)
        {
            _identityService = identityService;
            _profileService = profileService;
        }

        [Route("api/profile")]
        public async Task<IActionResult> Get()
        {
            //var userId = User.FindFirstValue(JwtClaimTypes.Subject);
            var userId = User.Identity.GetSubjectId();
            var user = await _identityService.GetUserAsync(userId);
            var profile  = await _profileService.GetProfile(userId);

            var result = new List<ApiResultItem>();
            result.Add(new ApiResultItem() { Name = "name", Value = profile.FullName });
            result.Add(new ApiResultItem() { Name = "bio", Value = profile.Bio });
            result.Add(new ApiResultItem() { Name = "phone", Value = user.PhoneNumber });
            result.Add(new ApiResultItem() { Name = "contact email", Value = user.Email });

            return new JsonResult(result);
        }

        [Route("api/photo")]
        public async Task<IActionResult> GetPhoto()
        {
            var userId = User.Identity.GetSubjectId();
            var profile = await _profileService.GetProfile(userId);

            var result = new
            {
                photo = profile.Photo
            };
            return new JsonResult(result);
        }

        [Route("api/claims")]
        public IActionResult GetClaims()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

    }

    internal class ApiResultItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
