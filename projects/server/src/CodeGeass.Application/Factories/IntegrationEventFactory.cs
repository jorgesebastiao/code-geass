using CodeGeass.Core.Outbox;
using CodeGeass.Core.Outbox.Factories;
using CodeGeass.SharedKernel.IntegrationsEvents;
using Newtonsoft.Json;
using System.Reflection;

namespace CodeGeass.Application.Factories
{
    internal class IntegrationEventFactory : IIntegrationEventFactory
    {
        private readonly Dictionary<string, Type> _eventTypes;

        public IntegrationEventFactory(Assembly integrationEventAssembly)
        {
            var baseEventType = typeof(IntegrationEvent);

            _eventTypes = integrationEventAssembly
                            .GetTypes()
                            .Where(e => baseEventType.IsAssignableFrom(e))
                            .ToDictionary(e => e.Name);
        }

        public IntegrationEvent Create(OutboxIntegrationEvent integrationEvent)
        {
            var eventType = _eventTypes[integrationEvent.EventName];
            var @event = JsonConvert.DeserializeObject(integrationEvent.Data, eventType);
            return (IntegrationEvent)@event;
        }
    }
}
