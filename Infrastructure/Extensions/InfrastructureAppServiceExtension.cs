using Infrastructure.Entities;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.RepositoryRelated.Repositories;
using Infrastructure.UnitOfWorkRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class InfrastructureAppServiceExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection Services, IConfiguration conf)
        {

            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IUserRepository, UserRepository>();
            
        }
    }
}
