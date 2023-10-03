using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCharacterUseCase : BaseUseCase<CreateCharacterInput>
    {
        private readonly ICharacterFactory _characterFactory;
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CreateCharacterUseCase(ICharacterFactory characterFactory, ICharacterRepository characterRepository, IMapper mapper) : base(mapper)
        {
            _characterFactory = characterFactory;
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public override async Task<Output> Handle(CreateCharacterInput input, CancellationToken cancellationToken)
        {
            var createCharacterCallback = await _characterFactory.CreateAsync(_mapper.Map<Character>, input, cancellationToken);
            if (createCharacterCallback.IsFailure)
                return Failure(createCharacterCallback.Failure);

            var addCharacterCallback = await _characterRepository.AddAsync(createCharacterCallback.Success, cancellationToken);
            if (addCharacterCallback.IsFailure)
                return Failure(addCharacterCallback.Failure);

            await _characterRepository.UnitOfWork.CommitAsync(cancellationToken);

            return Success();
        }
    }
}
