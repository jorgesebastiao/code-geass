using CodeGeass.Core.Data;
using CodeGeass.Infra.Extensions;
using CodeGeass.Infra.Settings;
using CodeGeass.KnightmareFrames.Application.Features;
using CodeGeass.KnightmareFrames.Domain.Features;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;
using CodeGeass.KnightmareFrames.Infra.Data.Base;
using CodeGeass.KnightmareFrames.Infra.Data.Contexts;
using CodeGeass.KnightmareFrames.Infra.Data.Features.KnightmareFrames;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeGeass.KnightmareFrames.Api.Extensions
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
                    var options = new DbContextOptionsBuilder<CodeGeassKnightmareFrameBdContext>().UseInMemoryDatabase(dataSettings.ConnectionString).Options;
                    return new CodeGeassKnightmareFrameBdContext(options, context.GetService<IMediator>(), context.GetService<IKnightmareFrameIntegrationEventMapper>());
                }
                else
                {
                    var options = new DbContextOptionsBuilder<CodeGeassKnightmareFrameBdContext>().UseOracle(dataSettings.ConnectionString).Options;
                    return new CodeGeassKnightmareFrameBdContext(options, context.GetService<IMediator>(), context.GetService<IKnightmareFrameIntegrationEventMapper>());
                }
            });

            services.AddDbContext<CodeGeassKnightmareFrameBdContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IKnightmareFrameIntegrationEventMapper, KnightmareFrameIntegrationEventMapper>();

            services.AddAggregates();
        }

        private static void AddAggregates(this IServiceCollection services)
        {
            services.AddKnightmareFrames();
        }

        private static void AddKnightmareFrames(this IServiceCollection services)
        {
            services.AddScoped<IKnightmareFrameRepository, KnightmareFrameRepository>();
        }
    }
}
