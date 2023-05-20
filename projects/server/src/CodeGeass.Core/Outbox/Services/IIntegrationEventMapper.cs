using CodeGeass.Core.Outbox.Factories;
using CodeGeass.SharedKernel.DomainEvent;

namespace CodeGeass.Core.Outbox.Services
{
    public interface IIntegrationEventMapper
    {
        public IIntegrationEventFactory Factory { get; }
        List<OutboxIntegrationEvent> Map(IEnumerable<DomainEvent> domainEvents);
    }
}
