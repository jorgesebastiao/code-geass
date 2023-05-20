using AutoMapper;
using CodeGeass.Application.Common;

namespace CodeGeass.Characters.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCharacterUseCase : BaseUseCase<DeleteCharacterInput>
    {
        public DeleteCharacterUseCase(IMapper mapper) : base(mapper)
        {

        }

        public override Task<Output> Handle(DeleteCharacterInput input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
