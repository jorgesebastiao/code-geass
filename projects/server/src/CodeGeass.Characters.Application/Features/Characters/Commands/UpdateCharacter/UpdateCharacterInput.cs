using CodeGeass.Application.Common;

namespace CodeGeass.Characters.Application.Features.Characters.Commands.UpdateCharacter
{
    public class UpdateCharacterInput : BaseCommandInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
