using AuthServer.Infrastructure.Common.Interfaces;
using AuthServer.Infrastructure.Common.Models;
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
using System.Threading.Tasks;

namespace AuthServer.Pages.Account.Manage
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserProfileService _profileService;
        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserProfileService profileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _profileService = profileService;
        }

        [BindProperty]
        public ProfileInputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public string Username { get; set; }

        public string Photo{ get; set; }


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


            var profile = new UserProfile();

            if (file != null)
            {
                Input.Photo = Upload(file);
            }
            


            //TODO: Validate if values are changed
            var phoneToken = await _userManager.GenerateChangePhoneNumberTokenAsync(user, Input.PhoneNumber);
            await _userManager.ChangePhoneNumberAsync(user, Input.PhoneNumber, phoneToken);
            var emailToken = await _userManager.GenerateChangeEmailTokenAsync(user, Input.ContactEmail);
            await _userManager.ChangeEmailAsync(user, Input.ContactEmail, emailToken);

            profile.Photo = Input.Photo ?? Photo;
            profile.UserId = user.Id;
            profile.FullName = Input.FullName ?? string.Empty;
            profile.Bio = Input.Bio ?? string.Empty;

            await _profileService.UpdateProfile(profile);
            await _signInManager.RefreshSignInAsync(user);

            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var profile = _profileService.GetProfile(user.Id);

            Username = userName;
            Photo = profile.Photo;

            Input = new ProfileInputModel
            {
                Email = user.UserName,
                PhoneNumber = phoneNumber ?? string.Empty,
                ContactEmail = email ?? string.Empty,
                Bio = profile.Bio,
                FullName= profile.FullName,
                Photo = profile.Photo
            };
        }
        
        private string Upload(IFormFile file)
        {
            string result = "";
            using var image = Image.Load(file.OpenReadStream());

            var width = 256;

            image.Mutate(x => x.Resize(width, GetHeight(width, image.Width, image.Height) ));

            using (var outputStream = new MemoryStream())
            {
                image.Save(outputStream, new JpegEncoder());
                var bytes = outputStream.ToArray();
                result = $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }

            return result;
        }

        private int GetHeight(int width, int sourceWidth, int sourceHeight) {

            int result = (sourceHeight * width) / sourceWidth;
            return result;
        }
    }

}

