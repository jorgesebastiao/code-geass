using CodeGeass.SharedKernel.DomainEvent;

namespace CodeGeass.Core.DomainObjects
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot() { }

        private List<DomainEvent> _domainEvents;

        public void AddDomainEvent(DomainEvent @event)
        {
            _domainEvents ??= new List<DomainEvent>();
            _domainEvents.Add(@event);
        }

        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
