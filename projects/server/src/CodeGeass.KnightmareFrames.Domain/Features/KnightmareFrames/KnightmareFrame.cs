using CodeGeass.Core.DomainObjects;

namespace CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames
{
    public class KnightmareFrame : AggregateRoot
    {

        public Guid CustomerId { get; private set; }

        public KnightmareFrame(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
