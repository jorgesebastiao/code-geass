using CodeGeass.Core.Data;
using CodeGeass.Core.DomainObjects;
using CodeGeass.Infra.Data.Base;
using CodeGeass.KnightmareFrames.Infra.Data.Contexts;

namespace CodeGeass.KnightmareFrames.Infra.Data.Base
{
    public sealed class Repository<TEntity> : Repository<TEntity, CodeGeassKnightmareFrameBdContext>, IRepository<TEntity> where TEntity : AggregateRoot
    {
        public Repository(CodeGeassKnightmareFrameBdContext context) : base(context) { }

    }
}
