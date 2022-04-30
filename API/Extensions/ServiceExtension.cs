using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Entities.User;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shared;
using API.Context;
using API.Middlewares;

namespace API
{
    public static class ServiceExtension
    {
        public static void ConfigureSwagger(this IServiceCollection Services)
        {

            Services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = JwtBearerDefaults.AuthenticationScheme,
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        Array.Empty<string>()
                        }
                     });
            });

        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }
        public static void AddOtherServices(this IServiceCollection Services)
        {

            Services.AddScoped<ValidationFilterAttribute>();
            Services.AddScoped(UserContextFactory.Create);
            Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
        public static void AddOptionsForObjects(this IServiceCollection Services, IConfiguration conf)
        {
            Services.Configure<JwtSettings>(conf.GetSection(typeof(JwtSettings).Name));
            Services.Configure<MailSettings>(conf.GetSection(typeof(MailSettings).Name));
        }
        public static void AddConnectionString (this IServiceCollection Services, IConfiguration conf)
        {

            Services.AddDbContext<EntityDbContext>(options =>
                options.UseSqlServer(conf.GetConnectionString("DefaultConnection")));
        }
    }
}
