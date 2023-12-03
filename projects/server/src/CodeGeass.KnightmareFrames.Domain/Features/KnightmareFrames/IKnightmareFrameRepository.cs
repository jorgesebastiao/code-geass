using CodeGeass.Core.Data;
using CodeGeass.SharedKernel.Result;

namespace CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames
{
    public interface IKnightmareFrameRepository : IAggregateRootRepository<KnightmareFrame>
    {
        Task<CodeGeassResult<KnightmareFrame>> AddAsync(KnightmareFrame knightmareFrame, CancellationToken cancellationToken);
        Task<CodeGeassResult<Unit>> DeleteAsync(KnightmareFrame knightmareFrame, CancellationToken cancellationToken);
        Task<CodeGeassResult<IQueryable<KnightmareFrame>>> GetAllAsync();
        Task<CodeGeassResult<KnightmareFrame>> GetByIdAsync(Guid knightmareFrameId, CancellationToken cancellationToken);
        Task<CodeGeassResult<KnightmareFrame>> UpdateAsync(KnightmareFrame knightmareFrame, CancellationToken cancellationToken);
        Task<CodeGeassResult<bool>> IsAlreadyExistsCode(string code, CancellationToken cancellationToken);

    }
}
