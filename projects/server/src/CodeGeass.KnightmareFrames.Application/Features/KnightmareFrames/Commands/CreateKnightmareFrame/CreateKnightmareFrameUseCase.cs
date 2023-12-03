using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.CreateKnightmareFrame
{
    public class CreateKnightmareFrameUseCase : BaseUseCase<CreateKnightmareFrameInput>
    {
        private readonly IKnightmareFrameFactory _knightmareFrameFactory;
        private readonly IKnightmareFrameRepository _knightmareFrameRepository;
        private readonly IMapper _mapper;

        public CreateKnightmareFrameUseCase(IKnightmareFrameFactory knightmareFrameFactory, IKnightmareFrameRepository knightmareFrameRepository, IMapper mapper) : base(mapper)
        {
            _knightmareFrameFactory = knightmareFrameFactory;
            _knightmareFrameRepository = knightmareFrameRepository;
            _mapper = mapper;
        }

        public override async Task<Output> Handle(CreateKnightmareFrameInput input, CancellationToken cancellationToken)
        {
            var createKnightmareFrameCallback = await _knightmareFrameFactory.CreateAsync(_mapper.Map<KnightmareFrame>, input, cancellationToken);
            if (createKnightmareFrameCallback.IsFailure)
                return Failure(createKnightmareFrameCallback.Failure);

            var addKnightmareFrameCallback = await _knightmareFrameRepository.AddAsync(createKnightmareFrameCallback.Success, cancellationToken);
            if (addKnightmareFrameCallback.IsFailure)
                return Failure(addKnightmareFrameCallback.Failure);

            return Success();
        }
    }
}
