using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.DeleteKnightmareFrame
{
    public class DeleteKnightmareFrameUseCase : BaseUseCase<DeleteKnightmareFrameInput>
    {
        private readonly IKnightmareFrameRepository _knightmareFrameRepository;

        public DeleteKnightmareFrameUseCase(IKnightmareFrameRepository knightmareFrameRepository, IMapper mapper) : base(mapper)
        {
            _knightmareFrameRepository = knightmareFrameRepository;
        }

        public override async Task<Output> Handle(DeleteKnightmareFrameInput input, CancellationToken cancellationToken)
        {
            var findKnightmareFrameCallback = await _knightmareFrameRepository.GetByIdAsync(input.KnightmareFrameId, cancellationToken);
            if (findKnightmareFrameCallback.IsFailure) return Failure(findKnightmareFrameCallback.Failure);

            var deleteKnightmareFrameCallback = await _knightmareFrameRepository.DeleteAsync(findKnightmareFrameCallback.Success, cancellationToken);
            if (deleteKnightmareFrameCallback.IsFailure) return Failure(deleteKnightmareFrameCallback.Failure);

            return Success();
        }
    }
}
