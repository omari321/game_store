using Application.User;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Entities.User;
using Infrastructure.Repositories;

namespace API
{
    public static class ServiceExtension
    {
        public static void AddDependencies(this IServiceCollection Services)
        {
            Services.AddControllers();           
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddDbContext<EntityDbContext>((sp, options) =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection", EnvironmentVariableTarget.Process));
                //write this before update-database
                //$env: DefaultConnection = "Data Source=(Local);Initial Catalog=GamesStore;Integrated Security=true;TrustServerCertificate=True"
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

    }
}
