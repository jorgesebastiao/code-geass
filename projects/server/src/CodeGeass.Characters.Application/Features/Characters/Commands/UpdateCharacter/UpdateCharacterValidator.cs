using FluentValidation;

namespace CodeGeass.Characters.Application.Features.Characters.Commands.UpdateCharacter
{
    public class UpdateCharacterValidator : AbstractValidator<UpdateCharacterInput>
    {
        public UpdateCharacterValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
