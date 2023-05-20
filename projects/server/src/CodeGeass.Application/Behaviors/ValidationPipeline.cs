using CodeGeass.Application.Common;
using CodeGeass.SharedKernel.Result;
using FluentValidation;
using MediatR;

namespace CodeGeass.Application.Behaviors
{
    /// <summary>
    /// classe do pipeline de validação do FLuentValidation
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public sealed class ValidationPipeline<TRequest, TOutput> : IPipelineBehavior<TRequest, TOutput>
     where TRequest : notnull
     where TOutput : Output, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// Cosntrutor do pipeline responsavel por executar as validações do FLuent Validations
        /// </summary
        /// <param name="validator"></param>
        public ValidationPipeline(IEnumerable<IValidator<TRequest>> validator)
        {
            _validators = validator;
        }

        /// <summary>
        /// Handler responsavel por executar as validações do FLuentValidation
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TOutput> Handle(TRequest request, RequestHandlerDelegate<TOutput> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                var output = new TOutput();
                output.AddFailure(CodeGeassResult.Fail(new ValidationException(failures)));
                return output;
            }

            return await next();
        }
    }
}
