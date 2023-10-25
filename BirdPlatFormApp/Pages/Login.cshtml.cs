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
        public async Task<IActionResult> OnPostGoogleLogin()
        {
            await googleAuth.GoogleLoginAsync();
            return RedirectToPage("/Index");
        }
        
    }
}
