using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;
using FizzWare.NBuilder;

namespace CodeGeass.KnightmareFrames.Infra.Data.Tests.Features.KnightmareFrames
{
    public static class KnightmareFrameRepositoryMock
    {
        public static IEnumerable<KnightmareFrame> GetKnightmareFrames(int size)
        {
            return Builder<KnightmareFrame>.CreateListOfSize(size)
                .Build();
        }
    }
}
