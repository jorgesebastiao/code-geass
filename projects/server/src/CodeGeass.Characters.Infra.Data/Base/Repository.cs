using CodeGeass.Characters.Infra.Data.Contexts;
using CodeGeass.Core.Data;
using CodeGeass.Core.DomainObjects;
using CodeGeass.Infra.Data.Base;

namespace CodeGeass.Characters.Infra.Data.Base
{
    public sealed class Repository<TEntity> : Repository<TEntity, CodeGeassCharacterBdContext>, IRepository<TEntity> where TEntity : AggregateRoot
    {

        public Repository(CodeGeassCharacterBdContext context) : base(context)
        {

        }
    }
}
