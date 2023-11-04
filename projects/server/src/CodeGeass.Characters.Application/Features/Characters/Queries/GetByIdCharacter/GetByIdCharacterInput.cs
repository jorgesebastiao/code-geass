using CodeGeass.Application.Common;

namespace CodeGeass.Characters.Application.Features.Characters.Queries.GetByIdCharacter
{
    public class GetByIdCharacterInput: BaseQueryInput
    {
        public Guid CharacterId { get; set; }
    }
}
