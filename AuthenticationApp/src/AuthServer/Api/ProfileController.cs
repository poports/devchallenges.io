using AuthServer.Infrastructure.Common.Interfaces;
using IdentityModel;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
            var userId = User.FindFirstValue(JwtClaimTypes.Subject);
            var user = await _identityService.GetUserAsync(userId);

            var result = new {
                email = user.Email,
                phone = user.PhoneNumber,
                photo = user.Photo,
                bio = user.Bio,
                name = user.FullName
            };

            return new JsonResult(result);
        }
    }
}
