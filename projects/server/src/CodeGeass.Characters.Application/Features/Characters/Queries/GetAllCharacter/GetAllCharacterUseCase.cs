using AutoMapper;
using CodeGeass.Application.Common;
using CodeGeass.Characters.Domain.Features.Characters;

namespace CodeGeass.Characters.Application.Features.Characters.Queries.GetAllCustomer
{
    public class GetAllCharacterUseCase : BaseUseCase<GetAllCharacterInput>
    {
        private readonly ICharacterRepository _customerRepository;

        public GetAllCharacterUseCase(ICharacterRepository customerRepository, IMapper mapper) : base(mapper)
        {
            _customerRepository = customerRepository;
        }

        public override async Task<Output> Handle(GetAllCharacterInput input, CancellationToken cancellationToken)
        {
            var getAllCustomerCallback = await _customerRepository.GetAllAsync();
            if (getAllCustomerCallback.IsFailure)
                return Failure(getAllCustomerCallback.Failure);

            return SuccessQueryable<Character, GetAllCharacterOutPut>(getAllCustomerCallback.Success);
        }
    }
}
