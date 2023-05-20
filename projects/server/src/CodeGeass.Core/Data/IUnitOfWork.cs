namespace CodeGeass.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> CommitAsync(CancellationToken cancellationToken);

    }
}
