using Application.Services.Admin;
using Application.Services.AuthenticationManagment;
using Application.Services.Category;
using Application.Services.CityCountry;
using Application.Services.JwtUtils;
using Application.Services.Mail;
using Application.Services.Publisher;
using Application.Services.OwnedGames;
using Application.Services.Videogame;
using Application.Services.VideogameCategoryService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.EnumCollections;
using Application.Services.User;
using Application.Services.PaymentCreditentials;
using Application.Services.VideogameImages;
using Application.Services.UserTransactionsBalance;

namespace Application.Extensions
{
    public static class ApplicationAppServiceExtension
    {
        public static void AddApplicationServices(this IServiceCollection Services)
        {
            Services.AddScoped<IAuthenticationService, AuthenticationService>();
            Services.AddScoped<IJwtUtilsService, JwtUtilsService>();
            Services.AddScoped<IMailService, MailService>();
            Services.AddScoped<IAdminService, AdminService>();
            Services.AddScoped<IPublisherService,PublisherService>();
            Services.AddScoped<IVideogameService, VideogameService>();
            Services.AddScoped<ICityCountryService, CityCountryService>();
            Services.AddScoped<IVideogameCategoryService, VideogameCategoryService>();
            Services.AddScoped<ICategoryService, CategoryService>();
            Services.AddScoped<IOwnedGamesService, OwnedGamesService>();
            Services.AddScoped<IEnumCollections, EnumCollections>();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IPaymentCreditentialsService, PaymentCreditentialsService>();
            Services.AddScoped<IVideogameImagesService, VideogameImagesService>();
            Services.AddScoped<IUserTransactionsAndBalanceService, UserTransactionsAndBalanceService>();
        } 
        public static void AddMailBackgroundProcessingServices(this IServiceCollection Services)
        {
            Services.AddScoped<IMailService, MailService>();
        }
    }
   
}
