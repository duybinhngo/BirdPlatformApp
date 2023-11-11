using Application.Authentication.Google;
using Google.Apis.Oauth2.v2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdPlatFormApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IGoogleAuth googleAuth;
        public LoginModel(IGoogleAuth googleAuth)
        {
            this.googleAuth = googleAuth;
        }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if(Username == "admin@gmail.com" && Password == "1")
            {
                return RedirectToPage("/AdminManageProvider/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostGoogleLogin()
        {
            await googleAuth.GoogleLoginAsync();
            return RedirectToPage("/BirdServicePages/Index");
        }
        
    }
}
