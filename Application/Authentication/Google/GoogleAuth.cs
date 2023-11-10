using Application.Authentication.Google.Settings;
using Application.Services.Interfaces;
using Domain;
using Domain.Entities;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;
using Infrastructure.Common;
using Infrastructure.InterfaceRepositories;
using Microsoft.AspNetCore.Http;
using Auth = Infrastructure.Common;

namespace Application.Authentication.Google
{
    public class GoogleAuth : IGoogleAuth
    {
        private readonly GoogleSetting googleSetting;
        private readonly GoogleResponse googleResponse;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICustomerRepository customerRepository;
        private readonly IProviderService providerService;
        public GoogleAuth(
            GoogleSetting googleSetting, 
            GoogleResponse googleResponse, 
            IHttpContextAccessor httpContextAccessor, 
            ICustomerRepository customerRepository,
            IProviderService providerService)
        {
            this.googleSetting = googleSetting;
            this.googleResponse = googleResponse;
            this.httpContextAccessor = httpContextAccessor;
            this.customerRepository = customerRepository;
            this.providerService = providerService;
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
            googleResponse.Credential = credential;

            ApplicationUser appUser = null;

            var provider = await providerService.GetAsyncByEmail(userInfo.Email);

            if(provider is null)
            {
                var customer = await customerRepository.Authenticated(userInfo.Email
                    , userInfo.Name, userInfo.Picture);
                if (customer is null) return null;
                
                appUser = new ApplicationUser()
                {
                    Id = customer.Id,
                    Email = customer.Email,
                    UserName = customer.Username,
                    IsActive = customer.IsActive,
                    AvatarUrl = customer.AvatarUrl,
                    RoleId = 1
                };
            }
            else
            {
                appUser = new ApplicationUser()
                {
                    Id = provider.Id,
                    Email = provider.Email,
                    UserName = provider.ProviderName,
                    IsActive = provider.IsActive,
                    AvatarUrl = provider.AvatarUrl,
                    RoleId = 2
                };
            }

            
            Auth::Authentication.SetAuthentication(httpContextAccessor.HttpContext, appUser);
            var result = Auth::Authentication.GetAuthenticatedUser(httpContextAccessor.HttpContext);
            return userInfo;
        }

        public async Task<bool> LogoutAsync()
        {
            Auth::Authentication.ClearAuthentication(httpContextAccessor.HttpContext);
            return await RevokeAsync();
        }

        private async Task<bool> RevokeAsync()
            => googleResponse.Credential is not null ? await googleResponse.Credential.RevokeTokenAsync(CancellationToken.None) : false;
    }
}
