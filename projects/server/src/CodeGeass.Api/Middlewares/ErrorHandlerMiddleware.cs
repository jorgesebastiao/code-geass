using CodeGeass.Api.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Mime;

namespace CodeGeass.Api.Middlewares
{
    /// <summary>
    /// Middleware responsavel para captura de exceções
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        /// <summary>
        /// Contrutor padrão
        /// </summary>
        /// <param name="next"></param>
        /// <param name="environment"></param>
        /// <param name="_logger"></param>
        public ErrorHandlerMiddleware(RequestDelegate next, IWebHostEnvironment environment, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _environment = environment;
            _logger = logger;
        }

        /// <summary>
        /// Método responsavel por processar as requisições Http
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await ResponseErrorAsync(context, e);
            }
        }

        private async Task ResponseErrorAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, $"Ocorreu um erro em [{nameof(ErrorHandlerMiddleware)}]");

            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;
            response.StatusCode = StatusCodes.Status500InternalServerError;

            var message = "Ocorreu um erro na sua requisição. Por favor, tente novamente";
            var problem = new ProblemDetails
            {
                Title = "Internal Server Error",
                Status = response.StatusCode,
                Detail = isDevelopment() ? exception.GetFirstException().Message : message,
                Instance = context.Request.HttpContext.Request.Path,
                Type = $"https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/{response.StatusCode}"
            };

            await response.WriteAsJsonAsync(problem);
        }

        private bool isDevelopment()
        {
            return _environment.IsEnvironment("Desenvolvimento") || _environment.IsEnvironment("Local");
        }
    }
}
