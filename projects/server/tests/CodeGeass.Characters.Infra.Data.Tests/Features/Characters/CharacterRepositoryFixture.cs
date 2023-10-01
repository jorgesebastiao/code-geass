using CodeGeass.Characters.Infra.Data.Features.Characters;
using FluentAssertions;
using Gwtdo.Scenarios;
using Gwtdo.Steps;

namespace CodeGeass.Characters.Infra.Data.Tests.Features.Characters
{
    using act = Act<CharacterRepositoryContext>;
    using arrange = Arrange<CharacterRepositoryContext>;
    using assert = Assert<CharacterRepositoryContext>;

    public class CharacterRepositoryFixture : ScenarioFixture<CharacterRepositoryContext>
    {
    }

    public static class Setup
    {
        public static arrange I_have_a_repository(this arrange fixtures)
        {
            return fixtures.Setup((f) =>
            {
                f.CharacterRepository = new CharacterRepository(f.Repository, f.DbContext);
            });
        }

        public static arrange Add_seed_characters(this arrange fixtures)
        {
            return fixtures.Setup((f) =>
            {
                f.DbContext.Characters.AddRange(CharacterRepositoryMock.GetCharacters(10));
                f.DbContext.SaveChanges();
            });
        }
    }

    public static class Exercise
    {
        public static act I_ask_to_getall(this act fixtures)
        {
            return fixtures.It(async f => f.Result = await f.CharacterRepository.GetAllAsync());
        }
    }

    public static class Verify
    {
        public static assert I_should_have_a_all_characters(this assert fixtures)
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
