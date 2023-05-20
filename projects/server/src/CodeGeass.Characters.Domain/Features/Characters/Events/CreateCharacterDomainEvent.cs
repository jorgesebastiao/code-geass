using CodeGeass.SharedKernel.DomainEvent;

namespace CodeGeass.Characters.Domain.Features.Characters.Events
{
    public record CreateCharacterDomainEvent(Character Character) : DomainEvent
    {

    }
}
