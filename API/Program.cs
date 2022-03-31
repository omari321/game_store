using API;
using API.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
    config.WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(),"LogFile.txt"));
});
//builder.Logging.ClearProviders();

ServiceExtension.AddDependencies(builder.Services);
ServiceExtension.ConfigureCors(builder.Services);
ServiceExtension.AddDependencies(builder.Services);

builder.Configuration.AddEnvironmentVariables(prefix: "environmentVariables");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandler();
app.UseAuthorization();
app.MapControllers();
app.Run();
