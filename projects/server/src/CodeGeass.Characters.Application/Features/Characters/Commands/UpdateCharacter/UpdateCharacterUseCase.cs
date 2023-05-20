using AutoMapper;
using CodeGeass.Application.Common;

namespace CodeGeass.Characters.Application.Features.Characters.Commands.UpdateCharacter
{
    public class UpdateCharacterUseCase : BaseUseCase<UpdateCharacterInput>
    {
        private readonly IMapper _mapper;

        public UpdateCharacterUseCase(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }

        public override Task<Output> Handle(UpdateCharacterInput input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
