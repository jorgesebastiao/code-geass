using CodeGeass.Core.DomainObjects;

namespace CodeGeass.Core.Outbox
{
    public class OutboxIntegrationEvent : AggregateRoot
    {
        public OutboxIntegrationEvent(string eventName, string data)
        {
            EventName = eventName;
            Data = data;
        }

        public string EventName { get; private set; }
        public string Data { get; private set; }
    }
}
