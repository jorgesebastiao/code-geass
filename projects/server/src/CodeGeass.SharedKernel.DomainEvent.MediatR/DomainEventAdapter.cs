using MediatR;

namespace CodeGeass.SharedKernel.DomainEvent.MediatR
{
    /// <summary>
    /// Classe utilizada para adaptar o domain event para ser processado pelo Mediator, seguindo a padrão de usar INotification
    /// </summary>
    public class DomainEventAdapter<TDomainEvent> : INotification where TDomainEvent : DomainEvent
    {
        public DomainEvent DomainEvent { get; }

        public DomainEventAdapter(DomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
