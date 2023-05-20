using CodeGeass.Application;
using CodeGeass.Characters.Domain.Features;
using CodeGeass.Characters.Domain.Features.Characters.Events;
using CodeGeass.IntegrationsEvents;
using CodeGeass.SharedKernel.IntegrationsEvents;
using System.Reflection;

namespace CodeGeass.Characters.Application.Features
{
    public class CharacterIntegrationEventMapper : IntegrationEventMapper, ICharacterIntegrationEventMapper
    {
        public CharacterIntegrationEventMapper() : base(typeof(IntegrationsEventsModule).GetTypeInfo().Assembly)
        {

        }

        protected override IntegrationEvent MapDomainEvent<T>(T domainEvent)
        {
            return domainEvent switch
            {
                CreateCharacterDomainEvent @event => new CharacterCreatedIntegrationEvent(@event.Character.Id, @event.Character.Name, @event.Character.NickName),
                { } => null
            };
        }
    }
}
