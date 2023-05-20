using CodeGeass.Core.Data;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;
using CodeGeass.SharedKernel.Result;

namespace CodeGeass.KnightmareFrames.Infra.Data.Features.KnightmareFrames
{
    public class KnightmareFrameRepository : IKnightmareFrameRepository
    {

        private readonly IRepository<KnightmareFrame> _repository;

        public KnightmareFrameRepository(IRepository<KnightmareFrame> repository)
        {
            _repository = repository;
        }

        public IUnitOfWork UnitOfWork => _repository.UnitOfWork;

        public async Task<CodeGeassResult<KnightmareFrame>> AddAsync(KnightmareFrame invoice, CancellationToken cancellationToken) => await _repository.AddAsync(invoice, cancellationToken);
        public async Task<CodeGeassResult<Unit>> DeleteAsync(KnightmareFrame invoice, CancellationToken cancellationToken) => await _repository.DeleteAsync(invoice, cancellationToken);
        public async Task<CodeGeassResult<IQueryable<KnightmareFrame>>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<CodeGeassResult<KnightmareFrame>> GetByIdAsync(Guid invoiceId, CancellationToken cancellationToken) => await _repository.GetByIdAsync(invoiceId, cancellationToken);
        public async Task<CodeGeassResult<KnightmareFrame>> UpdateAsync(KnightmareFrame invoice, CancellationToken cancellationToken) => await _repository.UpdateAsync(invoice, cancellationToken);

    }
}
