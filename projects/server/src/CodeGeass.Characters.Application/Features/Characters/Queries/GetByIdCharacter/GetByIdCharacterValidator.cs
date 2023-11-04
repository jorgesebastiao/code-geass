using FluentValidation;

namespace CodeGeass.Characters.Application.Features.Characters.Queries.GetByIdCharacter
{
    public class GetByIdCharacterValidator : AbstractValidator<GetByIdCharacterInput>
    {
        public GetByIdCharacterValidator()
        {
              RuleFor( x => x.CharacterId).NotEmpty().NotNull();  
        }
    }
}
