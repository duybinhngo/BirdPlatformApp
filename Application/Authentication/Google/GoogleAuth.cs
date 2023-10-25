using Application.Authentication.Google.Settings;
using BirdPlatFormApp.Services.Session;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;
using Infrastructure.InterfaceRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Application.Authentication.Google
{
    public class GoogleAuth : IGoogleAuth
    {
        private readonly GoogleSetting googleSetting;
        private readonly GoogleResponse googleResponse;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICustomerRepository customerRepository;
        public GoogleAuth(
            GoogleSetting googleSetting, 
            GoogleResponse googleResponse, 
            IHttpContextAccessor httpContextAccessor, 
            ICustomerRepository customerRepository)
        {
            this.googleSetting = googleSetting;
            this.googleResponse = googleResponse;
            this.httpContextAccessor = httpContextAccessor;
            this.customerRepository = customerRepository;
        }
        public async Task<Userinfo> GoogleLoginAsync()
        {
            string[] scopes = { "https://www.googleapis.com/auth/userinfo.email", "https://www.googleapis.com/auth/userinfo.profile" };
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets()
                {
                    ClientId = googleSetting.ClientId,
                    ClientSecret = googleSetting.ClientSecret,
                },
                scopes,
                "user",
                CancellationToken.None
            ).Result;
            var oauthSerivce = new Oauth2Service(
            new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
            });
            var userInfo = await oauthSerivce.Userinfo.Get().ExecuteAsync();

            var customer = customerRepository.Authenticated(userInfo.Email, userInfo.Name, userInfo.Picture);
            if (customer is null) return null;

            googleResponse.Credential = credential;
            httpContextAccessor.HttpContext.Session.SetObject("user", userInfo);
            return userInfo;
        }

        public async Task<bool> LogoutAsync()
        {
            httpContextAccessor.HttpContext.Session.Clear();
            return await RevokeAsync();
        }

        private async Task<bool> RevokeAsync()
            => googleResponse.Credential is not null ? await googleResponse.Credential.RevokeTokenAsync(CancellationToken.None) : false;
    }
}
