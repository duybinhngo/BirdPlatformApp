using Infrastructure.InterfaceRepositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BirdPlatFormApp
{
    public static class Registrations
    {
        public static IServiceCollection RegisterApp(this IServiceCollection services,
            IConfiguration configuration)
        {
            
            return services;
        }

    }
}
