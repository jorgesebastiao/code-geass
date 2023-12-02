using CodeGeass.KnightmareFrames.Infra.Data.Features.KnightmareFrames;
using FluentAssertions;
using Gwtdo.Scenarios;
using Gwtdo.Steps;

namespace CodeGeass.KnightmareFrames.Infra.Data.Tests.Features.KnightmareFrames
{
    using act = Act<KnightmareFrameRepositoryContext>;
    using arrange = Arrange<KnightmareFrameRepositoryContext>;
    using assert = Assert<KnightmareFrameRepositoryContext>;

    public class KnightmareFrameRepositoryFixture : ScenarioFixture<KnightmareFrameRepositoryContext>
    {
    }

    public static class Setup
    {
        public static arrange I_have_a_repository(this arrange fixtures)
        {
            return fixtures.Setup((f) =>
            {
                f.KnightmareFrameRepository = new KnightmareFrameRepository(f.Repository, f.DbContext);
            });
        }

        public static arrange Add_seed_KnightmareFrames(this arrange fixtures)
        {
            return fixtures.Setup((f) =>
            {
                f.DbContext.KnightmareFrames.AddRange(KnightmareFrameRepositoryMock.GetKnightmareFrames(10));
                f.DbContext.SaveChanges();
            });
        }
    }

    public static class Exercise
    {
        public static act I_ask_to_getall(this act fixtures)
        {
            return fixtures.It(async f => f.Result = await f.KnightmareFrameRepository.GetAllAsync());
        }
    }

    public static class Verify
    {
        public static assert I_should_have_a_all_KnightmareFrames(this assert fixtures)
        {
            return fixtures.Expect(x =>
            {
                x.Result.IsSuccess.Should().BeTrue();
                x.Result.Success.Should().NotBeNull();
                x.Result.Success.Should().HaveCount(10);
            });
        }
    }
}
