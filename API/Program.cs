using API;
using API.Middlewares;
using Application.Extensions;
using Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
    config.WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(),"LogFile.txt"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureCors();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddOtherServices();
builder.Services.AddOptionsForObjects(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddConnectionString(builder.Configuration);
builder.Services.BackgroundServiceAppServiceExtensionMethod();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleWare>();
app.UseMiddleware<JwtMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
