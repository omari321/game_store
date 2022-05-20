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
            Services.AddScoped<IVideogameRepository, VideogameRepository>();
            Services.AddScoped<IPublisherRepository, PublisherRepository>();
            Services.AddScoped<ICityRepository,CityRepository>();
            Services.AddScoped<ICountryRepository, CountryRepository>();
            Services.AddScoped<ICategoryRepository, CategoryRepository>();
            Services.AddScoped<IVideogameCategoryRepository, VideogameCategoryRepository>();
            Services.AddScoped<IPaymentCredentialRepository , PaymentCredentialRepository>();
            Services.AddScoped<ITransactionsRepository,TransactionsRepository>();
            Services.AddScoped<IOwnedGamesRepository, OwnedGamesRepository>();
            Services.AddScoped<IVideogameImagesRepository, VideogameImagesRepository>();
            Services.AddScoped<IUserBalanceRepository, UserBalanceRepository>();
            Services.AddScoped<IConfirmationMailToSendRepository, ConfirmationMailToSendRepository>();
            Services.AddScoped<IGameTransactionHistoryRepository , GameTransactionHistoryRepository>();
            Services.AddScoped<IVideogameFileRepository, VideogameFileRepository>();
        }
    }
}
