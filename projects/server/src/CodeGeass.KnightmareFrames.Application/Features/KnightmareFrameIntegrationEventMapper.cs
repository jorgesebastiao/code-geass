using CodeGeass.Application;
using CodeGeass.IntegrationsEvents;
using CodeGeass.KnightmareFrames.Domain.Features;
using CodeGeass.SharedKernel.IntegrationsEvents;
using System.Reflection;

namespace CodeGeass.KnightmareFrames.Application.Features
{
    public class KnightmareFrameIntegrationEventMapper : IntegrationEventMapper, IKnightmareFrameIntegrationEventMapper
    {
        public KnightmareFrameIntegrationEventMapper() : base(typeof(IntegrationsEventsModule).GetTypeInfo().Assembly)
        {

        }

        protected override IntegrationEvent MapDomainEvent<T>(T domainEvent)
        {
            return domainEvent switch
            {
                { } => null
            };
        }
    }
}
