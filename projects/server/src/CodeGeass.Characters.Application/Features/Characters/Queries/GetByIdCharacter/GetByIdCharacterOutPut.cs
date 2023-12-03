using CodeGeass.Application.Common;

namespace CodeGeass.Characters.Application.Features.Characters.Queries.GetByIdCharacter
{
    public class GetByIdCharacterOutPut : IOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
    }
}
