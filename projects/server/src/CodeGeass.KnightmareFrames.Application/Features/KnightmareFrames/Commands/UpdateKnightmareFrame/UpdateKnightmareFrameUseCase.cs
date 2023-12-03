using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.UpdateKnightmareFrame
{
    public class UpdateKnightmareFrameUseCase : BaseUseCase<UpdateKnightmareFrameInput>
    {
        private readonly IKnightmareFrameRepository _knightmareFrameRepository;
        private readonly IMapper _mapper;

        public UpdateKnightmareFrameUseCase(IKnightmareFrameRepository knightmareFrameRepository, IMapper mapper) : base(mapper)
        {
            _knightmareFrameRepository = knightmareFrameRepository;
            _mapper = mapper;
        }

        public override async Task<Output> Handle(UpdateKnightmareFrameInput input, CancellationToken cancellationToken)
        {
            var findKnightmareFrameCallback = await _knightmareFrameRepository.GetByIdAsync(input.Id, cancellationToken);
            if (findKnightmareFrameCallback.IsFailure) return Failure(findKnightmareFrameCallback.Failure);

            _mapper.Map(input, findKnightmareFrameCallback.Success);

            var updateKnightmareFrameCallback = await _knightmareFrameRepository.UpdateAsync(findKnightmareFrameCallback.Success, cancellationToken);
            if (updateKnightmareFrameCallback.IsFailure) return Failure(updateKnightmareFrameCallback.Failure);

            return Success();
        }
    }
}
