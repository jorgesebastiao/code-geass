using CodeGeass.Characters.Domain.Features.Characters;
using FizzWare.NBuilder;

namespace CodeGeass.Characters.Infra.Data.Tests.Features.Characters
{
    public static class CharacterRepositoryMock
    {
        public static IEnumerable<Character> GetCharacters(int size)
        {
            return Builder<Character>.CreateListOfSize(size)
                .Build();
        }
    }
}
