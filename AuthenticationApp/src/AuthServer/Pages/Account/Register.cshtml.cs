using AuthServer.Infrastructure.Common.Interfaces;
using AuthServer.Infrastructure.Identity;
using AuthServer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        IIdentityService _identityService;
        SignInManager<ApplicationUser> _signInManager;
        public RegisterModel(IIdentityService identityService, SignInManager<ApplicationUser> signInManager)
        {
            _identityService = identityService;
            _signInManager = signInManager;
        }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public async Task OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                
                var action = await _identityService.CreateUserAsync(Input.Email, Input.Password);
                if (action.Result.Succeeded) {
                    var user = await _identityService.GetUserAsync(action.UserId);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in action.Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

    }
}
