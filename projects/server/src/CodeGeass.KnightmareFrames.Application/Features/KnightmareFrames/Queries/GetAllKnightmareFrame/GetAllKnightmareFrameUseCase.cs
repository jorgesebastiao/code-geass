using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Queries.GetAllKnightmareFrame
{
    public class GetAllKnightmareFrameUseCase : BaseUseCase<GetAllKnightmareFrameInput>
    {
        private readonly IKnightmareFrameRepository _knightmareFrameRepository;

        public GetAllKnightmareFrameUseCase(IKnightmareFrameRepository knightmareFrameRepository, IMapper mapper) : base(mapper)
        {
            _knightmareFrameRepository = knightmareFrameRepository;
        }

        public override async Task<Output> Handle(GetAllKnightmareFrameInput input, CancellationToken cancellationToken)
        {
            var getAllKnightmareFrameCallback = await _knightmareFrameRepository.GetAllAsync();
            if (getAllKnightmareFrameCallback.IsFailure)
                return Failure(getAllKnightmareFrameCallback.Failure);

            return SuccessQueryable<KnightmareFrame, GetAllKnightmareFrameOutPut>(getAllKnightmareFrameCallback.Success);
        }
    }
}
