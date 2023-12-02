using Gwtdo;
using Xunit;

namespace CodeGeass.KnightmareFrames.Infra.Data.Tests.Features.KnightmareFrames
{
    public class KnightmareFrameRepositoryTest : Feature<KnightmareFrameRepositoryContext, KnightmareFrameRepositoryFixture>, IClassFixture<KnightmareFrameRepositoryContext>, IDisposable
    {
        public KnightmareFrameRepositoryTest(KnightmareFrameRepositoryContext context) : base(context)
        {
        }

        [Fact]
        public void Should_return_list_of_all_the_KnightmareFrames()
        {
            FeatureContext.Setup();

            GIVEN
                .I_have_a_repository()
                .Add_seed_KnightmareFrames();

            WHEN
                .I_ask_to_getall();

            THEN
                .I_should_have_a_all_KnightmareFrames();
        }

        public void Dispose()
        {
            FeatureContext.TearDown();
        }
    }
}
