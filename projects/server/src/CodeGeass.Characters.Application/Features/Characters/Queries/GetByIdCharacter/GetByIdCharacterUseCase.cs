using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Characters.Queries.GetByIdCharacter
{
    public class GetByIdCharacterUseCase : BaseUseCase<GetByIdCharacterInput>
    {
        private readonly ICharacterRepository _characterRepository;

        public GetByIdCharacterUseCase(ICharacterRepository characterRepository, IMapper mapper) : base(mapper)
        {
            _characterRepository = characterRepository;
        }

        public override async Task<Output> Handle(GetByIdCharacterInput input, CancellationToken cancellationToken)
        {
            var findCharacterCallback = await _characterRepository.GetByIdAsync(input.CharacterId, cancellationToken);
            if (findCharacterCallback.IsFailure)
                return Failure(findCharacterCallback.Failure);

            return Success<Character, GetByIdCharacterOutPut>(findCharacterCallback.Success);
        }
    }
}
