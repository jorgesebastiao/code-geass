using CodeGeass.Characters.Domain.Features.Characters.Events;
using CodeGeass.Core.Exceptions;
using CodeGeass.SharedKernel.FactoryPattern;
using CodeGeass.SharedKernel.Result;

namespace CodeGeass.Characters.Domain.Features.Characters
{
    public interface ICharacterFactory : IFactory<Character>
    {

    }

    public class CharacterFactory : ICharacterFactory
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterFactory(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<CodeGeassResult<Character>> CreateAsync<TCommand>(Func<TCommand, Character> mapFunc, TCommand command, CancellationToken cancellationToken)
        {
            var character = mapFunc(command);

            var isAlreadyExistNickNameCallback = await _characterRepository.IsAlreadyExistsNickName(character.NickName, cancellationToken);

            if (isAlreadyExistNickNameCallback.IsFailure)
                return isAlreadyExistNickNameCallback.Failure;

            if (isAlreadyExistNickNameCallback.Success)
                return new AlreadyExistsException();

            character.AddDomainEvent(new CreateCharacterDomainEvent(character));

            return character;
        }

    }
}
