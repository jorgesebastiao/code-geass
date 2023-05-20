using CodeGeass.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CodeGeass.Api.Extensions
{
    /// <summary>
    ///  Classe estática que implementa um método de extensão no qual é registrado o middleware
    ///  UseMiddleware para lidar com erros globais.
    ///</summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        ///  Método de extensão que registra o middleware do tipo ExceptionMiddleware para lidar com erros globais.
        ///</summary>
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
