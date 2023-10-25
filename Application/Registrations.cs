using Infrastructure.InterfaceRepositories;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Application.Authentication.Google.Settings;
using Microsoft.AspNetCore.Authentication.Google;
using Application.Authentication.Google;

namespace Application
{
    public static class Registrations
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.RegisterAuthentication(configuration);
            return services;
        }
        private static IServiceCollection RegisterAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            var _googleSettings = configuration.GetSection(GoogleSetting.GoogleSection).Get<GoogleSetting>();
            services.AddSingleton(_ => _googleSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
            {
                options.ClientId = _googleSettings.ClientId;
                options.ClientSecret = _googleSettings.ClientSecret;
            });

            services.AddScoped<IGoogleAuth, GoogleAuth>();
            services.AddSingleton<GoogleResponse>();
            return services;
        }
    }
}
