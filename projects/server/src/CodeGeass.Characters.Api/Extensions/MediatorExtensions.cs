using CodeGeass.Application;
using CodeGeass.Application.Behaviors;
using CodeGeass.Characters.Application;
using System.Reflection;

namespace CodeGeass.Characters.Api.Extensions
{
    /// <summary>
    /// Classe de extensão responsavel pela configuração do Mediatr
    /// </summary>
    public static class MediatorExtensions
    {
        /// <summary>
        /// Método de extensão responsavel pela configuração do Mediatr
        /// </summary>
        /// <param name="services"></param>
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(GetAssemblies().ToArray());
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
                cfg.AddOpenBehavior(typeof(ValidationPipeline<,>));
                cfg.AddOpenBehavior(typeof(TransactionPipeline<,>));
            });
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(Program).GetTypeInfo().Assembly;
            yield return typeof(AppModule).GetTypeInfo().Assembly;
            yield return typeof(CharactersAppModule).GetTypeInfo().Assembly;
        }
    }
}
