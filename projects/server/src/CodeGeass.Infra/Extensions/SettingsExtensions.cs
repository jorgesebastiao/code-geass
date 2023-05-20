using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeGeass.Infra.Extensions
{
    /// <summary>
    /// Classe de extensão responsavel por extrar as informações das configurações(AppSettings,Variaveis de Ambiente)
    /// </summary>
    public static class SettingsExtensions
    {
        /// <summary>
        /// Método de extensão responsável por carregar as configurações pela Section Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <param name="sectionName"></param>
        /// <param name="service"></param>
        /// <returns> return T</returns>
        public static T LoadSettings<T>(this IConfiguration configuration, string sectionName, IServiceCollection? service = null) where T : class
        {
            var sections = configuration.GetSection(sectionName);
            service?.Configure<T>(sections);

            var settings = sections.Get<T>();
            return settings;
        }
    }
}
