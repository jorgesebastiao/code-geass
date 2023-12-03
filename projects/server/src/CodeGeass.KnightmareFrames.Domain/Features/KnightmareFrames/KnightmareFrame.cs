using CodeGeass.Core.DomainObjects;

namespace CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames
{
    public class KnightmareFrame : AggregateRoot
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Generation { get; private set; }

        protected KnightmareFrame() { }

        public KnightmareFrame(string name, string code, string generation)
        {
            Name = name;
            Code = code;
            Generation = generation;
        }
    }
}
