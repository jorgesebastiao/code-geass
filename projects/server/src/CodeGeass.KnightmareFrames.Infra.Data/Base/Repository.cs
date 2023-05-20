using CodeGeass.Core.Data;
using CodeGeass.Core.DomainObjects;
using CodeGeass.Infra.Data.Base;
using CodeGeass.KnightmareFrames.Infra.Data.Contexts;

namespace CodeGeass.KnightmareFrames.Infra.Data.Base
{
    public sealed class Repository<TEntity> : Repository<TEntity, CodeGeassInvoiceBdContext>, IRepository<TEntity> where TEntity : AggregateRoot
    {
        public Repository(CodeGeassInvoiceBdContext context) : base(context) { }

    }
}
