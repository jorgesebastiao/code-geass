using CodeGeass.Characters.Infra.Data.Contexts;
using CodeGeass.Infra.Extensions;
using CodeGeass.Infra.Settings;
using Microsoft.EntityFrameworkCore;

namespace CodeGeass.Characters.Api.Extensions
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
                var locadoraDbContext = scope.ServiceProvider.GetRequiredService<CodeGeassCharacterBdContext>();
                locadoraDbContext.Database.EnsureCreated();
            }
            else
            {
                using var scope = app.Services.CreateScope();
                var locadoraDbContext = scope.ServiceProvider.GetRequiredService<CodeGeassCharacterBdContext>();
                locadoraDbContext.Database.Migrate();
            }
        }
    }
}
