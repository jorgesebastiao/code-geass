using MediatR;

namespace CodeGeass.SharedKernel.DomainEvent
{
    public abstract record DomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
