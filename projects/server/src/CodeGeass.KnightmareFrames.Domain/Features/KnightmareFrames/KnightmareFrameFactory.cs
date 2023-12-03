using CodeGeass.Core.Exceptions;
using CodeGeass.SharedKernel.FactoryPattern;
using CodeGeass.SharedKernel.Result;

namespace CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames
{

    public interface IKnightmareFrameFactory : IFactory<KnightmareFrame>
    {

    }

    public class KnightmareFrameFactory : IKnightmareFrameFactory
    {
        private readonly IKnightmareFrameRepository _knightmareFrameRepository;

        public KnightmareFrameFactory(IKnightmareFrameRepository knightmareFrameRepository)
        {
            _knightmareFrameRepository = knightmareFrameRepository;
        }

        public async Task<CodeGeassResult<KnightmareFrame>> CreateAsync<TCommand>(Func<TCommand, KnightmareFrame> mapFunc, TCommand command, CancellationToken cancellationToken)
        {
            var knightmareFrame = mapFunc(command);

            var isAlreadyExistCodeCallback = await _knightmareFrameRepository.IsAlreadyExistsCode(knightmareFrame.Code, cancellationToken);

            if (isAlreadyExistCodeCallback.IsFailure)
                return isAlreadyExistCodeCallback.Failure;

            if (isAlreadyExistCodeCallback.Success)
                return new AlreadyExistsException();


            return knightmareFrame;
        }

    }
}
