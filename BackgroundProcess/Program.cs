using API;
using Application.Extensions;
using BackgroundProcesses;
using BackgroundProcesses.SendMail;
using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMailBackgroundProcessingServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddOptionsForObjects(builder.Configuration);
builder.Services.AddHostedService<Processing>();
builder.Services.AddConnectionString(builder.Configuration);
builder.Services.AddSingleton<IMailVerifyProcessor, MailVerifyProcessor>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.


app.Run();

