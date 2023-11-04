using Gwtdo;
using Xunit;

namespace CodeGeass.Characters.Infra.Data.Tests.Features.Characters
{
    public class CharacterRepositoryTest : Feature<CharacterRepositoryContext, CharacterRepositoryFixture>, IClassFixture<CharacterRepositoryContext>, IDisposable
    {
        public CharacterRepositoryTest(CharacterRepositoryContext context) : base(context)
        {
        }

        [Fact]
        public void Should_return_list_of_all_the_characters()
        {
            FeatureContext.Setup();

            GIVEN
                .I_have_a_repository()
                .Add_seed_characters();

            WHEN
                .I_ask_to_getall();

            THEN
                .I_should_have_a_all_characters();
        }

        public void Dispose()
        {
            FeatureContext.TearDown();
        }
    }
}
