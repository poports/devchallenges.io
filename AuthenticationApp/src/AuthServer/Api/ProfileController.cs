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
        public ProfileController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [Route("api/profile")]
        public async Task<IActionResult> Get()
        {
            //var userId = User.FindFirstValue(JwtClaimTypes.Subject);
            var userId = User.Identity.GetSubjectId();
            var user = await _identityService.GetUserAsync(userId);
            var claims = await _identityService.GetClaimsAsync(user);

            var result = new List<ApiResultItem>();
            result.Add(new ApiResultItem() { Name = "name", Value = claims?.FirstOrDefault(x => x.Type.Equals("name", StringComparison.OrdinalIgnoreCase))?.Value });
            result.Add(new ApiResultItem() { Name = "bio", Value = claims?.FirstOrDefault(x => x.Type.Equals("bio", StringComparison.OrdinalIgnoreCase))?.Value });
            result.Add(new ApiResultItem() { Name = "phone", Value = claims?.FirstOrDefault(x => x.Type.Equals("phone", StringComparison.OrdinalIgnoreCase))?.Value });
            result.Add(new ApiResultItem() { Name = "contact email", Value = claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase))?.Value });

            return new JsonResult(result);
        }

        [Route("api/photo")]
        public async Task<IActionResult> GetPhoto()
        {
            var userId = User.Identity.GetSubjectId();
            var user = await _identityService.GetUserAsync(userId);
            var claims = await _identityService.GetClaimsAsync(user);

            var photoClaim = claims?.FirstOrDefault(x => x.Type.Equals("photo", StringComparison.OrdinalIgnoreCase))?.Value;

            var result = new
            {
                photo = photoClaim
            };
            

            return new JsonResult(result);
        }

    }

    internal class ApiResultItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
