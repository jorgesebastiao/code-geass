
using CodeGeass.SharedKernel.IntegrationsEvents;

namespace CodeGeass.Core.Outbox.Factories
{
    public interface IIntegrationEventFactory
    {
        IntegrationEvent Create(OutboxIntegrationEvent integrationEvent);
    }
}
