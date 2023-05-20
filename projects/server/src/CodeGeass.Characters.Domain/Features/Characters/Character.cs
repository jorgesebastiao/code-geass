using CodeGeass.Core.DomainObjects;

namespace CodeGeass.Characters.Domain.Features.Characters
{
    public class Character : AggregateRoot
    {
        public string Name { get; private set; }
        public string NickName { get; private set; }

        protected Character() { }

        public Character(string name, string nickName)
        {
            Name = name;
            NickName = nickName;
        }
    }
}
