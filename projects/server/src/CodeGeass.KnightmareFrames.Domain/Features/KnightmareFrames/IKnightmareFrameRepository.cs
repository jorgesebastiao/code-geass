using CodeGeass.Core.Data;
using CodeGeass.SharedKernel.Result;

namespace CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames
{
    public interface IKnightmareFrameRepository : IAggregateRootRepository<KnightmareFrame>
    {
        Task<CodeGeassResult<KnightmareFrame>> AddAsync(KnightmareFrame invoice, CancellationToken cancellationToken);
        Task<CodeGeassResult<Unit>> DeleteAsync(KnightmareFrame invoice, CancellationToken cancellationToken);
        Task<CodeGeassResult<IQueryable<KnightmareFrame>>> GetAllAsync();
        Task<CodeGeassResult<KnightmareFrame>> GetByIdAsync(Guid invoiceId, CancellationToken cancellationToken);
        Task<CodeGeassResult<KnightmareFrame>> UpdateAsync(KnightmareFrame invoice, CancellationToken cancellationToken);
    }
}
