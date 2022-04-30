using API;
using Application.Extensions;
using BackgroundProcesses;
using BackgroundProcesses.SendMail;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

var host = builder.ConfigureServices((context,services )=>
{
    var config=context.Configuration;
    services.AddApplicationServices();
    services.AddServices(config);
    services.AddOptionsForObjects(config);

    services.AddHostedService<Processing>();
    
    //Workers
    services.AddSingleton<IMailVerifyProcessor, MailVerifyProcessor>();
}).Build();

host.RunAsync();