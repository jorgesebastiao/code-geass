using CodeGeass.Infra.Extensions;
using CodeGeass.Infra.Settings;
using CodeGeass.KnightmareFrames.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CodeGeass.KnightmareFrames.Api.Extensions
{
    /// <summary>
    /// Extensão responsavel por aplicar as migrações no banco de dados
    /// </summary>
    public static class MigrationsExtensions
    {
        /// <summary>
        /// Método responsavel por aplicar as migrações no banco de dados
        /// </summary>
        /// <param name="app"></param>
        public static void ApplyMigrations(this WebApplication app)
        {
            var dataSettings = app.Configuration.LoadSettings<DataSettings>("DataSettings");
            if (dataSettings.UseInMemoryDatabase)
            {
                using var scope = app.Services.CreateScope();
                var locadoraDbContext = scope.ServiceProvider.GetRequiredService<CodeGeassInvoiceBdContext>();
                locadoraDbContext.Database.EnsureCreated();
            }
            else
            {
                using var scope = app.Services.CreateScope();
                var locadoraDbContext = scope.ServiceProvider.GetRequiredService<CodeGeassInvoiceBdContext>();
                locadoraDbContext.Database.Migrate();
            }
        }
    }
}
