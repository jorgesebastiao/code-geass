using CodeGeass.Application;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CodeGeass.KnightmareFrames.Api.Extensions
{
    /// <summary>
    /// Classe de extensão resposável pela configuração de incialização das aplicações MVC
    /// </summary>
    public static class MvcExtensions
    {
        /// <summary>
        /// Método de extensão responsável por adicionar as configurações MVC ao startup da aplicação
        /// </summary>
        /// <param name="services"></param>
        public static void AddMVC(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(AppModule).Assembly);

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            })
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                opt.SerializerSettings.Formatting = Formatting.None;
                opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });

            services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
