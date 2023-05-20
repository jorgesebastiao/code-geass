using Asp.Versioning.ApiExplorer;
using CodeGeass.Infra.Extensions;
using CodeGeass.KnightmareFrames.Api.Settings;
using CodeGeass.SharedKernel.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CodeGeass.KnightmareFrames.Api.Extensions
{
    /// <summary>
    /// Classe de extensão responsável pelas configurações do swagger
    /// </summary>
    public static class SwaggerExtensions
    {

        /// <summary>
        /// Método de extensão responsavel por inicializar o Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            // Registra o Swagger para documentar a API
            var swaggerSettings = configuration.LoadSettings<SwaggerSettings>("SwaggerSettings");

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider();
                var service = provider.GetRequiredService<IApiVersionDescriptionProvider>();
                service.ApiVersionDescriptions.ToList().ForEach(description =>
                {
                    options.SwaggerDoc(description.GroupName, CreateOpenApiInfoForApiVersion(description));
                });

                //TODO: To Enable oauth2 authorization code using Swagger 
                //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Description = "OAuth2.0 Auth Code with PKCE",
                //    Name = "oauth2",
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        AuthorizationCode = new OpenApiOAuthFlow
                //        {
                //            AuthorizationUrl = new Uri(swaggerSettings.AuthorizationUrl),
                //            TokenUrl = new Uri(swaggerSettings.TokenUrl),
                //            Scopes = new Dictionary<string, string> { { swaggerSettings.Scopes, "read the api" } }
                //        }
                //    }
                //});
                options.OperationFilter<AuthorizeCheckOperationFilter>(swaggerSettings.Scopes);
                options.SchemaFilter<EnumSchemaFilter>();
                options.UseInlineDefinitionsForEnums();

                // Adiciona os comentários da API no Swagger JSON da UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        private static OpenApiInfo CreateOpenApiInfoForApiVersion(ApiVersionDescription description)
        {
            var openApiInfo = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "CodeGeass.KnightmareFrames.Api",
                Description = "CodeGeass.KnightmareFrames.Api",
                TermsOfService = new Uri("https://codeGeass.jorgesebastiao.me"),
                Contact = new OpenApiContact
                {
                    Name = "CodeGeass.KnightmareFrames.Api",
                    Email = string.Empty,
                    Url = new Uri("https://codeGeass.jorgesebastiao.me")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://codeGeass.jorgesebastiao.me")
                }
            };
            return openApiInfo;
        }

        /// <summary>
        /// Método de extensão resposavel por configurar a inicialização do Swagger e SwaggerUI
        /// </summary>
        /// <param name="app"></param>
        public static void CoonfigSwagger(this WebApplication app)
        {
            var swaggerSettings = app.Configuration.LoadSettings<SwaggerSettings>("SwaggerSettings");

            //Habilida o Middeware do Swagger
            app.UseSwagger();

            //Configura o Swagger JSON endpoint
            app.UseSwaggerUI(options =>
            {
                var descriptions = app.DescribeApiVersions();

                options.OAuthClientId(swaggerSettings.OAuthClientId);
                options.OAuthScopes(swaggerSettings.Scopes);
                options.OAuthAppName("CodeGeass.KnightmareFrames.Api - Swagger");
                options.OAuthUsePkce();
                options.OAuthScopeSeparator(" ");

                string swaggerJsonBasePath = options.RoutePrefix.IsNullOrEmpty() ? "." : "..";
                foreach (var description in descriptions)
                {
                    var url = $"{swaggerJsonBasePath}/swagger/{description.GroupName}/swagger.json";
                    var name = description.GroupName.ToUpperInvariant();
                    options.SwaggerEndpoint(url, name);
                }
                options.RoutePrefix = string.Empty;
            });
        }

        /// <summary>
        /// Filtro responsavel pelo controle de Autorização
        /// </summary>
        public class AuthorizeCheckOperationFilter : IOperationFilter
        {
            private string _scopes;
            /// <summary>
            /// Cosntrutor padrão AuthorizeCheckOperationFilter
            /// </summary>
            /// <param name="scopes"></param>
            public AuthorizeCheckOperationFilter(string scopes)
            {
                _scopes = scopes;
            }

            /// <summary>
            /// Método responsavel por aplicar as  configurações de filtros do swagger
            /// </summary>
            /// <param name="operation"></param>
            /// <param name="context"></param>
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                                   context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

                if (hasAuthorize)
                {
                    operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                    operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

                    operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [new OpenApiSecurityScheme {Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "oauth2"}}] = new[] { _scopes }
                    }
                };
                }
            }
        }

        /// <summary>
        /// Filtro responsavel pela descrição dos Enums
        /// </summary>
        public class EnumSchemaFilter : ISchemaFilter
        {
            /// <summary>
            /// Método responsavel por aplicar as configurações de schema nos enums
            /// </summary>
            /// <param name="schema"></param>
            /// <param name="context"></param>
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (context.Type.IsEnum)
                {
                    schema.Enum.Clear();
                    Enum.GetNames(context.Type)
                        .ToList()
                        .ForEach(name => schema.Enum.Add(new OpenApiString($"{Convert.ToInt64(Enum.Parse(context.Type, name))} - {name}")));
                }
            }
        }
    }
}
