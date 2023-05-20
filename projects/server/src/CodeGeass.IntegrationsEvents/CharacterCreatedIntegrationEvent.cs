
using CodeGeass.SharedKernel.IntegrationsEvents;

namespace CodeGeass.IntegrationsEvents
{
    public class CharacterCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }

        public CharacterCreatedIntegrationEvent(Guid characterId, string name, string nickName)
        {
            CharacterId = characterId;
            Name = name;
            NickName = nickName;
        }
    }
}
