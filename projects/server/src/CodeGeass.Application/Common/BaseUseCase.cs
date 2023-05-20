using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeGeass.SharedKernel.Result;

namespace CodeGeass.Application.Common
{
    public abstract class BaseUseCase<TInput> : IBaseUseCase<TInput, Output> where TInput : BaseInput
    {
        private readonly IMapper _mapper;

        protected Output Output { get; set; }

        protected BaseUseCase(IMapper mapper)
        {
            Output = new Output();
            _mapper = mapper;
        }

        public Output Success()
        {
            Output.AddResult(CodeGeassResult.Ok());
            return Output;
        }

        public Output Success<TOutput>(TOutput output) where TOutput : IOutput
        {
            Output.AddResult(CodeGeassResult.Ok(output));
            return Output;
        }

        public Output Success<TDomain, TOutput>(TDomain domain) where TOutput : IOutput
        {
            Output.AddResult(CodeGeassResult.Ok(_mapper.Map<TOutput>(domain)));
            return Output;
        }

        public Output SuccessQueryable<TDomain, TOutput>(IQueryable<TDomain> domain) where TOutput : IOutput
        {
            Output.AddResult(CodeGeassResult.Ok(domain.ProjectTo<TOutput>(_mapper.ConfigurationProvider)));
            return Output;
        }

        public Output Failure<TFailure>(TFailure failure) where TFailure : Exception
        {
            Output.AddFailure(CodeGeassResult.Fail(failure));
            return Output;
        }

        public abstract Task<Output> Handle(TInput input, CancellationToken cancellationToken);
    }
}
