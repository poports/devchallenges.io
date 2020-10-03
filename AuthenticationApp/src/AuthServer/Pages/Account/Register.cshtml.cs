using AuthServer.Infrastructure.Common.Interfaces;
using AuthServer.Infrastructure.Common.Models;
using AuthServer.Infrastructure.Identity;
using AuthServer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AuthServer.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IIdentityService _identityService;
        private readonly IUserProfileService _profileService;
        private readonly SignInManager<ApplicationUser> _signInManager;
         public RegisterModel(IIdentityService identityService, SignInManager<ApplicationUser> signInManager, IUserProfileService profileService)
        {
            _identityService = identityService;
            _signInManager = signInManager;
            _profileService = profileService;
        }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public AccountInputModel Input { get; set; }

        public async Task OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/authentication/login");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var profile = new UserProfile()
                {
                    FullName = string.Empty,
                    Bio = string.Empty,
                    Photo = string.Empty
                };

                var (Result, UserId) = await _identityService.CreateUserAsync(Input.Email, Input.Password);
                var profileResult = await _profileService.CreateProfile(profile);

                if (Result.Succeeded && profileResult != null ) {
                    var user = await _identityService.GetUserAsync(UserId);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                if (profileResult == null) {
                    ModelState.AddModelError(string.Empty, "Error adding profile");
                }
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            } 
            // If we got this far, something failed, redisplay form
            return Page();
        }

    }
}
