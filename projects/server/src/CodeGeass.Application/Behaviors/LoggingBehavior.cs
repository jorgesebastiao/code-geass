using CodeGeass.Application.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CodeGeass.Application.Behaviors
{
    /// <summary>
    /// classe do pipeline de loggind de inicio e fim da execução do Handler
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public sealed class LoggingBehavior<TRequest, TOutput> : IPipelineBehavior<TRequest, TOutput>
    where TRequest : notnull
    where TOutput : Output
    {

        private readonly ILogger<LoggingBehavior<TRequest, TOutput>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TOutput>> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Handler responsavel por executar a escrita de log da execução do handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TOutput> Handle(TRequest request, RequestHandlerDelegate<TOutput> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"[{request.GetType().Name}][Handle] Iniciando fluxo...");

            var response = await next();

            if (response.Result.IsFailure)
                _logger.LogError($"[{request.GetType().Name}][Handle] {response.Result.Failure.Message}");

            _logger.LogInformation($"[{request.GetType().Name}][Handle] Finalizando fluxo...");

            return response;
        }
    }
}
