using API;
using Application.Extensions;
using BackgroundProcesses;
using BackgroundProcesses.SendMail;
using BackgroundProcesses.SendMails2;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

var host = builder.ConfigureServices((context,services )=>
{
    var config=context.Configuration;
    services.AddApplicationServices();
    services.AddInfrastructureServices(config);
    services.AddOptionsForObjects(config);
    services.AddHostedService<Processing2>();
    //services.AddHostedService<Processing>();
    services.AddConnectionString(config);
    //Workers
    //services.AddSingleton<IMailVerifyProcessor, MailVerifyProcessor>();
}).Build();
//this doesnt work
host.RunAsync();