using CodeGeass.Infra.Extensions;
using CodeGeass.IntegrationsEvents;
using CodeGeass.KnightmareFrames.Api.Settings;
using Rebus.Config;
using Rebus.Transport;
using System.Reflection;

namespace CodeGeass.KnightmareFrames.Api.Extensions
{
    /// <summary>
    /// Classe de extensão responsavel por configurar o Rebus
    /// </summary>
    public static class RebusExtensions
    {
        /// <summary>
        /// Método de extensão responsável por configurar o rebus
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigRebus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRebus((configure, provider) =>
            {
                configure.Logging(l => l.Serilog())
                         .Transport(t => t.GetTransport(configuration));
                return configure;
            },
            onCreated: async bus =>
            {
                await bus.Subscribe<CharacterCreatedIntegrationEvent>();
            });

            services.AutoRegisterHandlersFromAssembly(typeof(Startup).GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Método de extensão responsável por se inscrever nos eventos de integração
        /// </summary>
        /// <param name="app"></param>
        public static void SubscribeRebus(this IApplicationBuilder app)
        {
            app.ApplicationServices.StartRebus();
        }

        private static void GetTransport(this StandardConfigurer<ITransport> standardConfigurer, IConfiguration configuration)
        {
            var rebusSettings = configuration.LoadSettings<RebusSettings>("RebusSettings");
            standardConfigurer.UseRabbitMq(rebusSettings.ConnectionString, rebusSettings.QueueName);
        }
    }
}
