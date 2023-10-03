using FluentValidation;

namespace CodeGeass.Characters.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCharacterValidator : AbstractValidator<DeleteCharacterInput>
    {
        public DeleteCharacterValidator()
        {
            RuleFor(x => x.CharacterId).NotEmpty().NotNull();
        }
    }
}
