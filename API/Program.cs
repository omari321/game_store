using API;
using API.Middlewares;
using Application.Extensions;
using Infrastructure.Extensions;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSerilog(new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/Information.txt", LogEventLevel.Information, rollingInterval: RollingInterval.Day)
    .WriteTo.File("Logs/Error.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day)
    .CreateLogger());

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
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
