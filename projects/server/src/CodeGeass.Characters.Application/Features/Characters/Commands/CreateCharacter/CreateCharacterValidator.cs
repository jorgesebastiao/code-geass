using FluentValidation;

namespace CodeGeass.Characters.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCharacterValidator : AbstractValidator<CreateCharacterInput>
    {
        public CreateCharacterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.NickName).NotEmpty().NotNull();
        }
    }
}
