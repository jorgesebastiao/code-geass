namespace CodeGeass.KnightmareFrames.Api.Extensions
{
    /// <summary>
    /// Classe de extensão responsavel por inicializar o AutoMapper
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Método de extensão responsavel por adicionar Automapper na aplicação
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program), typeof(Application.KnightmareFramesAppModule));
        }
    }
}
