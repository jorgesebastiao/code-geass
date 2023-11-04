using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Characters.Commands.UpdateCharacter
{
    public class UpdateCharacterUseCase : BaseUseCase<UpdateCharacterInput>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public UpdateCharacterUseCase(ICharacterRepository characterRepository, IMapper mapper) : base(mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public override async Task<Output> Handle(UpdateCharacterInput input, CancellationToken cancellationToken)
        {
            var findCharacterCallback = await _characterRepository.GetByIdAsync(input.Id, cancellationToken);
            if (findCharacterCallback.IsFailure) return Failure(findCharacterCallback.Failure);

            _mapper.Map(input, findCharacterCallback.Success);

            var updateCharacterCallback = await _characterRepository.UpdateAsync(findCharacterCallback.Success, cancellationToken);
            if(updateCharacterCallback.IsFailure)  return Failure(updateCharacterCallback.Failure);

            return Success();
        }
    }
}
