using CodeGeass.Infra.Extensions;
using CodeGeass.KnightmareFrames.Api.Settings;

namespace CodeGeass.KnightmareFrames.Api.Extensions
{
    /// <summary>
    /// Classe de extensão resposnavel pela configuração do Cors
    /// </summary>
    public static class CORSExtensions
    {
        /// <summary>
        /// Método de extensão responsavel pela configuração do CORS
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection AddCORS(this IServiceCollection services, IConfiguration configuration)
        {
            var corsSettings = configuration.LoadSettings<CORSSettings>("CORSSettings") ?? new CORSSettings().Default();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(corsSettings.Origins)
                           .WithMethods(corsSettings.Methods)
                           .WithHeaders(corsSettings.Headers);
                });
            });

            return services;
        }

        /// <summary>
        /// Método de extensão responsavel pela configuração do CORS
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        public static void UseCORS(this WebApplication app, IConfiguration configuration)
        {
            app.UseCors();
        }
    }
}
