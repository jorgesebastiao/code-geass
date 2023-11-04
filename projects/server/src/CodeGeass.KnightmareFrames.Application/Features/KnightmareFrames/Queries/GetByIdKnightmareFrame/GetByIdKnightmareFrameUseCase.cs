using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Queries.GetByIdKnightmareFrame
{
    public class GetByIdKnightmareFrameUseCase : BaseUseCase<GetByIdKnightmareFrameInput>
    {
        private readonly IKnightmareFrameRepository _knightmareFrameRepository;

        public GetByIdKnightmareFrameUseCase(IKnightmareFrameRepository knightmareFrameRepository, IMapper mapper) : base(mapper)
        {
            _knightmareFrameRepository = knightmareFrameRepository;
        }

        public override async Task<Output> Handle(GetByIdKnightmareFrameInput input, CancellationToken cancellationToken)
        {
            var findKnightmareFrameCallback = await _knightmareFrameRepository.GetByIdAsync(input.KnightmareFrameId, cancellationToken);
            if (findKnightmareFrameCallback.IsFailure)
                return Failure(findKnightmareFrameCallback.Failure);

            return Success<KnightmareFrame, GetByIdKnightmareFrameOutPut>(findKnightmareFrameCallback.Success);
        }
    }
}
