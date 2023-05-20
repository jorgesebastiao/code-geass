using CodeGeass.Characters.Api;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.ConfigureConfiguration();
builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(context.Configuration));
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();
app.Configure();

await app.RunAsync();

