using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;

namespace BirdPlatFormApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.RegisterApp(Configuration)
                    .RegisterInfrastructure(Configuration)
                    .RegisterApplication(Configuration)
                    .RegisterRepository();

            services.AddMvc().AddRazorPagesOptions(
                options => options.Conventions.AddPageRoute("/Login", "")
            );

            services.AddHttpContextAccessor().AddAuthentication();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(45);
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.UseRewriter(new RewriteOptions().AddRedirectToHttps());
        }
    }
}
