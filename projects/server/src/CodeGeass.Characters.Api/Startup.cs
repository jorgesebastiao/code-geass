using CodeGeass.Api.Extensions;
using CodeGeass.Characters.Api.Extensions;
using CodeGeass.Characters.Infra.Data.Contexts;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.NewtonsoftJson;

namespace CodeGeass.Characters.Api
{
    /// <summary>
    /// Classe de extensão responsavel pela inicialização da aplicação
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Método de extensão responsavel por inciiar as configurações de ambiente
        /// </summary>
        /// <param name="configuration"></param>
        public static void ConfigureConfiguration(this ConfigurationManager configuration)
        {
            configuration.SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", false, true)
                         .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
                         .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// Método de extensão responsavel pela inicialização dos serviços
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                    .AddOData(options => options.Select().Filter().Count().OrderBy().Expand().SetMaxTop(1000))
                    .AddODataNewtonsoftJson();

            services.AddApiVersion();

            services.AddMediator();
            services.AddAutoMapper();
            services.AddCORS(configuration);
            services.AddHttpContextAccessor();

            services.AddMVC();
            services.AddSwagger(configuration);

            services.AddHealthChecksMiddleware<CodeGeassCharacterBdContext>();
            services.AddDependecies(configuration);
            services.ConfigRebus(configuration);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.ConfigQuartz(configuration);
            return services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Método de estensão responsavel por configurar a inicialização dos serviços
        /// </summary>
        /// <param name="app"></param>
        public static WebApplication Configure(this WebApplication app)
        {
            if (app.Environment.IsEnvironment("Local"))
            {
                app.UseODataRouteDebug();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseCORS(app.Configuration);

            app.CoonfigSwagger();

            app.UseExceptionMiddleware();

            app.UseAuthentication();
            app.UseAuthorization();

            // Add OData /$query middleware
            app.UseODataQueryRequest();

            // Add the OData Batch middleware to support OData $Batch
            app.UseODataBatching();

            app.UseHealthyChecksMiddleware();

            app.ApplyMigrations();

            app.MapControllers();
            return app;
        }
    }
}
