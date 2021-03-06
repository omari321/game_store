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
using System.Text.Json.Serialization;

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

            Services
            .AddMvc()
            // Or .AddControllers(...)
            .AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });

        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        }
        public static void AddOtherServices(this IServiceCollection Services)
        {

            Services.AddScoped<ValidationFilterAttribute>();
            Services.AddScoped(UserContextFactory.Create);
            Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            Services.AddSingleton(sp =>
            {
                var webHostEnvironment= sp.CreateScope().ServiceProvider.GetService<IWebHostEnvironment>();
                return new BasePath(webHostEnvironment.ContentRootPath);
            });
            Services.AddSingleton(sp =>
            {
                var configuration=sp.CreateScope().ServiceProvider.GetService<IConfiguration>();
                var url=configuration.GetValue<string>("ASPNETCORE_URLS");
                return new BaseUrl { applicationUrl = url };
            });
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
