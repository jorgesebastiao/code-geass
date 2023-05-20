using CodeGeass.Characters.Application.Features;
using CodeGeass.Characters.Domain.Features;
using CodeGeass.Characters.Domain.Features.Characters;
using CodeGeass.Characters.Infra.Data.Base;
using CodeGeass.Characters.Infra.Data.Contexts;
using CodeGeass.Characters.Infra.Data.Features.Characters;
using CodeGeass.Core.Data;
using CodeGeass.Infra.Extensions;
using CodeGeass.Infra.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeGeass.Characters.Api.Extensions
{
    /// <summary>
    /// Classe de extensão responsável pelo gerenciamento das injeções de dependencias 
    /// </summary>
    public static class DependencyInjectionExtensions
    {

        /// <summary>
        /// Método de extensão responsável por adicionar as dependencias ao container de IOC
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO: Implementação será adicionado quando for configurado a integraão com o banco de dados
            var dataSettings = configuration.LoadSettings<DataSettings>("DataSettings");

            services.AddScoped(context =>
            {
                if (dataSettings.UseInMemoryDatabase)
                {
                    var options = new DbContextOptionsBuilder<CodeGeassCharacterBdContext>().UseInMemoryDatabase(dataSettings.ConnectionString).Options;
                    return new CodeGeassCharacterBdContext(options, context.GetService<IMediator>(), context.GetService<ICharacterIntegrationEventMapper>());
                }
                else
                {
                    var options = new DbContextOptionsBuilder<CodeGeassCharacterBdContext>().UseOracle(dataSettings.ConnectionString).Options;
                    return new CodeGeassCharacterBdContext(options, context.GetService<IMediator>(), context.GetService<ICharacterIntegrationEventMapper>());
                }
            });

            services.AddDbContext<CodeGeassCharacterBdContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICharacterIntegrationEventMapper, CharacterIntegrationEventMapper>();

            services.AddAggregates();
        }

        private static void AddAggregates(this IServiceCollection services)
        {
            services.AddCharacters();
        }

        private static void AddCharacters(this IServiceCollection services)
        {
            services.AddScoped<ICharacterFactory, CharacterFactory>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
        }
    }
}
