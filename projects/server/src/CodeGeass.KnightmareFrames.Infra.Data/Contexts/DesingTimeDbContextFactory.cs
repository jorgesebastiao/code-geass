using CodeGeass.Infra.Extensions;
using CodeGeass.Infra.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CodeGeass.KnightmareFrames.Infra.Data.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CodeGeassInvoiceBdContext>
    {
        public CodeGeassInvoiceBdContext CreateDbContext(string[] args)
        {
            var configEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{configEnvironment}.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CodeGeassInvoiceBdContext>();

            var appSettings = config.LoadSettings<DataSettings>("DataSettings");

            optionsBuilder.UseOracle(appSettings.ConnectionString);

            return new CodeGeassInvoiceBdContext(optionsBuilder.Options);
        }
    }
}
