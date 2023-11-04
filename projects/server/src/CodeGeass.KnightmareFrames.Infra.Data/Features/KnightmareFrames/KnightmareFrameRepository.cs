using CodeGeass.Core.Data;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;
using CodeGeass.KnightmareFrames.Infra.Data.Contexts;
using CodeGeass.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace CodeGeass.KnightmareFrames.Infra.Data.Features.KnightmareFrames
{
    public class KnightmareFrameRepository : IKnightmareFrameRepository
    {

        private readonly IRepository<KnightmareFrame> _repository;
        private readonly CodeGeassKnightmareFrameBdContext _context;

        public KnightmareFrameRepository(IRepository<KnightmareFrame> repository, CodeGeassKnightmareFrameBdContext context)
        {
            _repository = repository;
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _repository.UnitOfWork;

        public async Task<CodeGeassResult<KnightmareFrame>> AddAsync(KnightmareFrame knightmareFrame, CancellationToken cancellationToken) => await _repository.AddAsync(knightmareFrame, cancellationToken);
        public async Task<CodeGeassResult<Unit>> DeleteAsync(KnightmareFrame knightmareFrame, CancellationToken cancellationToken) => await _repository.DeleteAsync(knightmareFrame, cancellationToken);
        public async Task<CodeGeassResult<IQueryable<KnightmareFrame>>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<CodeGeassResult<KnightmareFrame>> GetByIdAsync(Guid knightmareFrameId, CancellationToken cancellationToken) => await _repository.GetByIdAsync(knightmareFrameId, cancellationToken);
        public async Task<CodeGeassResult<KnightmareFrame>> UpdateAsync(KnightmareFrame knightmareFrame, CancellationToken cancellationToken) => await _repository.UpdateAsync(knightmareFrame, cancellationToken);
        public async Task<CodeGeassResult<bool>> IsAlreadyExistsCode(string code, CancellationToken cancellationToken)
        {
            return await CodeGeassResultExtension.Run(() => _context.KnightmareFrames.AnyAsync(c => c.Code.Equals(code), cancellationToken));
        }
    }
}
