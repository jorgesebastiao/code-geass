using CodeGeass.Application.Factories;
using CodeGeass.Core.Outbox;
using CodeGeass.Core.Outbox.Factories;
using CodeGeass.Core.Outbox.Services;
using CodeGeass.SharedKernel.DomainEvent;
using CodeGeass.SharedKernel.IntegrationsEvents;
using Newtonsoft.Json;
using System.Reflection;

namespace CodeGeass.Application
{
    public abstract class IntegrationEventMapper : IIntegrationEventMapper
    {
        public IntegrationEventMapper(Assembly integrationEventAssembly)
        {
            Factory = new IntegrationEventFactory(integrationEventAssembly);
        }

        public IIntegrationEventFactory Factory { get; }

        public List<OutboxIntegrationEvent> Map(IEnumerable<DomainEvent> domainEvents)
        {
            var integrationEvents = domainEvents.Select(e => MapDomainEvent(e))
                                                .Where(e => e != null)
                                                .ToList();

            return integrationEvents.Select(e => MapIntegrationEvent(e)).ToList();
        }

        protected abstract IntegrationEvent MapDomainEvent<T>(T domainEvent) where T : DomainEvent;

        private OutboxIntegrationEvent MapIntegrationEvent(IntegrationEvent integrationEvent)
        {
            var json = JsonConvert.SerializeObject(integrationEvent);
            return new OutboxIntegrationEvent(integrationEvent.GetType().Name, json);
        }
    }
}
