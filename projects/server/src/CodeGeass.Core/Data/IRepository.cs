using CodeGeass.Core.DomainObjects;
using CodeGeass.SharedKernel.Result;
using System.Linq.Expressions;

namespace CodeGeass.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<CodeGeassResult<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<CodeGeassResult<Unit>> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task<CodeGeassResult<IQueryable<TEntity>>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<CodeGeassResult<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<CodeGeassResult<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
