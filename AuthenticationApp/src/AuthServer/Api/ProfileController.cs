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

namespace AuthServer.Api
{
    [Route("/api/profile")]
    [Authorize(AuthenticationSchemes = IdentityServerConstants.LocalApi.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public ProfileController(IIdentityService identityService)
        {
            _identityService =  identityService;
        }

        public async Task<IActionResult> Get()
        {
            //var userId = User.FindFirstValue(JwtClaimTypes.Subject);
            var userId = User.Identity.GetSubjectId();
            var user = await _identityService.GetUserAsync(userId);
            var claims = await _identityService.GetClaimsAsync(user);

            var result = new
            {
                email = claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase))?.Value, 
                phone = claims?.FirstOrDefault(x => x.Type.Equals("phone", StringComparison.OrdinalIgnoreCase))?.Value,
                bio = claims?.FirstOrDefault(x => x.Type.Equals("bio", StringComparison.OrdinalIgnoreCase))?.Value,
                name = claims?.FirstOrDefault(x => x.Type.Equals("name", StringComparison.OrdinalIgnoreCase))?.Value
            };

            return new JsonResult(result);
        }
    }
}
