using MediatR;

namespace CodeGeass.Application.Common
{
    public interface IBaseUseCase<TInput, TOutput> : IRequestHandler<TInput, Output> where TInput : BaseInput
    {

    }
}
