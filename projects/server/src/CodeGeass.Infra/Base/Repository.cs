using CodeGeass.Core.Data;
using CodeGeass.Core.DomainObjects;
using CodeGeass.Core.Exceptions;
using CodeGeass.Infra.Base;
using CodeGeass.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeGeass.Infra.Data.Base
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>, IDisposable where TEntity : AggregateRoot where TContext : DbContextBase<TContext>
    {
        private readonly DbContextBase<TContext> _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContextBase<TContext> context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<CodeGeassResult<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var newEntity = _dbSet.Add(entity).Entity;

            var saveChangesCallback = await CodeGeassResultExtension.Run(async () => await _context.SaveChangesAsync(cancellationToken));
            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return newEntity;
        }

        public async Task<CodeGeassResult<Unit>> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);

            var saveChangesCallback = await CodeGeassResultExtension.Run(() => _context.SaveChangesAsync(cancellationToken));

            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return Unit.Successful;
        }

        public async Task<CodeGeassResult<IQueryable<TEntity>>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await Task.FromResult(query.AsNoTracking().AsResult());
        }

        public async Task<CodeGeassResult<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entityCallback = await CodeGeassResultExtension.Run(() => _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken));

            if (entityCallback.IsFailure)
                return entityCallback.Failure;

            if (entityCallback.Success == null)
                return new NotFoundException();

            return entityCallback;
        }

        public async Task<CodeGeassResult<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);

            var saveChangesCallback = await CodeGeassResultExtension.Run(() => _context.SaveChangesAsync(cancellationToken));

            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return entity;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
