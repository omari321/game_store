using Application.Services.Admin;
using Application.Services.AuthenticationManagment;
using Application.Services.JwtUtils;
using Application.Services.Mail;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ApplicationAppServiceExtension
    {
        public static void AddApplicationServices(this IServiceCollection Services)
        {
            Services.AddScoped<IAuthenticationService, AuthenticationService>();
            Services.AddScoped<IJwtUtilsService, JwtUtilsService>();
            Services.AddAutoMapper((cfg) =>
            {
                cfg.AddMaps(new[]
                {
                    "Application"
                });
            });
            Services.AddScoped<IMailService, MailService>();
            Services.AddScoped<IAdminService, AdminService>();
        }
    }
}
