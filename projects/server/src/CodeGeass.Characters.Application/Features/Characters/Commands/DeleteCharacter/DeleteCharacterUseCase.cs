using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCharacterUseCase : BaseUseCase<DeleteCharacterInput>
    {
        private readonly ICharacterRepository _characterRepository;

        public DeleteCharacterUseCase(ICharacterRepository characterRepository, IMapper mapper) : base(mapper)
        {
            _characterRepository = characterRepository;
        }

        public override async Task<Output> Handle(DeleteCharacterInput input, CancellationToken cancellationToken)
        {
            var findCharacterCallback = await _characterRepository.GetByIdAsync(input.CharacterId, cancellationToken);
            if (findCharacterCallback.IsFailure) return Failure(findCharacterCallback.Failure);

            var deleteCharacterCallback = await _characterRepository.DeleteAsync(findCharacterCallback.Success, cancellationToken);
            if (deleteCharacterCallback.IsFailure) return Failure(deleteCharacterCallback.Failure);

            return Success();
        }
    }
}
