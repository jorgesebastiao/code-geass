using Asp.Versioning;

namespace CodeGeass.KnightmareFrames.Api.Extensions
{
    /// <summary>
    /// Classe de extensão responsavel por configurar o Versionamento da API
    /// </summary>
    public static class ApiVersionExtensions
    {
        /// <summary>
        /// Método de extenssão responsavel por adicionar o Versionamento na aplicação
        /// </summary>
        /// <param name="services"></param>
        public static void AddApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            })
            .AddOData(options => options.AddRouteComponents())
            .AddODataApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
