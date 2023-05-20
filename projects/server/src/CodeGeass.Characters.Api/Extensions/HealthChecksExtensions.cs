using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

namespace CodeGeass.Characters.Api.Extensions
{
    /// <summary>
    /// Classe de extensão responsavel pela verificação de saude da aplicação
    /// </summary>
    public static class HealthChecksExtensions
    {
        /// <summary>
        /// Método de extensao responsavel por configar Health check
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddHealthChecksMiddleware<T>(this IServiceCollection service) where T : DbContext
        {
            service.AddHealthChecks()
               .AddDbContextCheck<T>();

            return service;
        }

        /// <summary>
        /// Método de extensão responsavel por habiltiar Health Check
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHealthyChecksMiddleware(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {

                // The default value is false.
                AllowCachingResponses = false
            });

            return app;
        }
    }
}
