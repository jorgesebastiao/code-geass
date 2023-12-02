using CodeGeass.Infra.Extensions;
using CodeGeass.Infra.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CodeGeass.KnightmareFrames.Infra.Data.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CodeGeassKnightmareFrameBdContext>
    {
        public CodeGeassKnightmareFrameBdContext CreateDbContext(string[] args)
        {
            var configEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{configEnvironment}.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CodeGeassKnightmareFrameBdContext>();

            var appSettings = config.LoadSettings<DataSettings>("DataSettings");

            optionsBuilder.UseInMemoryDatabase(appSettings.ConnectionString);

            return new CodeGeassKnightmareFrameBdContext(optionsBuilder.Options);
        }
    }
}
