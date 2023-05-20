using CodeGeass.Core.DomainObjects;

namespace CodeGeass.Core.Data
{
    public interface IAggregateRootRepository<TEntity> where TEntity : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

    }
}
