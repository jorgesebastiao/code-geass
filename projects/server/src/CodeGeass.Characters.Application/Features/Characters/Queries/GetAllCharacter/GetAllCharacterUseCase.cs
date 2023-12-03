using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.Characters.Application.Features.Characters.Queries.GetAllCustomer;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Characters.Queries.GetAllCharacter
{
    public class GetAllCharacterUseCase : BaseUseCase<GetAllCharacterInput>
    {
        private readonly ICharacterRepository _characterRepository;

        public GetAllCharacterUseCase(ICharacterRepository characterRepository, IMapper mapper) : base(mapper)
        {
            _characterRepository = characterRepository;
        }

        public override async Task<Output> Handle(GetAllCharacterInput input, CancellationToken cancellationToken)
        {
            var getAllCharacterCallback = await _characterRepository.GetAllAsync();
            if (getAllCharacterCallback.IsFailure)
                return Failure(getAllCharacterCallback.Failure);

            return SuccessQueryable<Character, GetAllCharacterOutPut>(getAllCharacterCallback.Success);
        }
    }
}
