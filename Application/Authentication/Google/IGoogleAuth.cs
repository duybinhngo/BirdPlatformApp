using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2.Data;

namespace Application.Authentication.Google
{
    public interface IGoogleAuth
    {
        public Task<Userinfo> GoogleLoginAsync();
        public Task<bool> LogoutAsync();
    }
}
