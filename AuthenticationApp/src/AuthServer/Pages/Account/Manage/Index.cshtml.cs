using AuthServer.Infrastructure.Identity;
using AuthServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthServer.Pages.Account.Manage
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public ProfileInputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public string Username { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var claims = await _userManager.GetClaimsAsync(user);

            if (file != null)
            {
                Input.Photo = Upload(file);
                await _userManager.ReplaceClaimAsync(user, claims?.FirstOrDefault(x => x.Type.Equals("photo", StringComparison.OrdinalIgnoreCase)), new Claim("photo", Input.Photo ?? string.Empty));
            }
            await _userManager.ReplaceClaimAsync(user, claims?.FirstOrDefault(x => x.Type.Equals("phone", StringComparison.OrdinalIgnoreCase)), new Claim ("phone", Input.PhoneNumber ?? string.Empty));
            await _userManager.ReplaceClaimAsync(user, claims?.FirstOrDefault(x => x.Type.Equals("name", StringComparison.OrdinalIgnoreCase)), new Claim("name", Input.FullName ?? string.Empty));
            await _userManager.ReplaceClaimAsync(user, claims?.FirstOrDefault(x => x.Type.Equals("bio", StringComparison.OrdinalIgnoreCase)), new Claim("bio", Input.Bio ?? string.Empty));
            await _userManager.ReplaceClaimAsync(user, claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase)), new Claim("email", Input.ContactEmail?? string.Empty));

            await _signInManager.RefreshSignInAsync(user);

            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);

            Username = userName;

            Input = new ProfileInputModel
            {
                Email = user.UserName,
                PhoneNumber = claims?.FirstOrDefault(x => x.Type.Equals("phone", StringComparison.OrdinalIgnoreCase))?.Value,
                ContactEmail = claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase))?.Value,
                Bio = claims?.FirstOrDefault(x => x.Type.Equals("bio", StringComparison.OrdinalIgnoreCase))?.Value,
                FullName= claims?.FirstOrDefault(x => x.Type.Equals("name", StringComparison.OrdinalIgnoreCase))?.Value,
                Photo = claims?.FirstOrDefault(x => x.Type.Equals("photo", StringComparison.OrdinalIgnoreCase))?.Value
            };
        }

        private string Upload(IFormFile file)
        {
            string result = "";
            using var image = Image.Load(file.OpenReadStream());
            //image.Mutate(x => x.Resize(128, 128));
            using (var outputStream = new MemoryStream())
            {
                image.Save(outputStream, new JpegEncoder());
                var bytes = outputStream.ToArray();
                result = $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }

            return result;
        }
    }
}
