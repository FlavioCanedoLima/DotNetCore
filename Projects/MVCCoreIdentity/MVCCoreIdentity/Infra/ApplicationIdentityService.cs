using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MVCCoreIdentity.Infra
{
    public class IdentityConfiguration
    {
        readonly IServiceCollection _services; 

        public IdentityConfiguration(IServiceCollection services)
        {
            _services = services;
            Configure();
            ConfigureCookie();
            ConfigureAuthorization();
        }

        private void Configure()
        {
            _services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
        }

        private void ConfigureCookie()
        {
            _services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            
        }

        private void ConfigureAuthorization()
        {
            _services.AddAuthorization(options =>
            {
                options.AddPolicy("About", policy => policy.RequireClaim("About", new string[] { "GET" }));
            });
            
        }
    }
}
