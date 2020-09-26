using AuthServer.Infrastructure.Common.Interfaces;
using AuthServer.Infrastructure.Identity;
using AuthServer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AuthServer.Pages.Account
{
    public class LoginModel : PageModel
    {
        IIdentityService _identityService;
        SignInManager<ApplicationUser> _signInManager;
        public LoginModel(IIdentityService identityService, SignInManager<ApplicationUser> signInManager)
        {
            _identityService = identityService;
            _signInManager = signInManager;
        }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public AccountInputModel Input { get; set; }
        public void OnGet()
        {
        }
    }
}
