using CodeGeass.Characters.Domain.Features.Characters;
using CodeGeass.Characters.Infra.Data.Contexts;
using CodeGeass.Core.Data;
using CodeGeass.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace CodeGeass.Characters.Infra.Data.Features.Characters
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IRepository<Character> _repository;
        private readonly CodeGeassCharacterBdContext _context;

        public CharacterRepository(IRepository<Character> repository, CodeGeassCharacterBdContext context)
        {
            _repository = repository;
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _repository.UnitOfWork;

        public async Task<CodeGeassResult<Character>> AddAsync(Character customer, CancellationToken cancellationToken) => await _repository.AddAsync(customer, cancellationToken);
        public async Task<CodeGeassResult<Unit>> DeleteAsync(Character customer, CancellationToken cancellationToken) => await _repository.DeleteAsync(customer, cancellationToken);
        public async Task<CodeGeassResult<IQueryable<Character>>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<CodeGeassResult<Character>> GetByIdAsync(Guid customerId, CancellationToken cancellationToken) => await _repository.GetByIdAsync(customerId, cancellationToken);
        public async Task<CodeGeassResult<Character>> UpdateAsync(Character customer, CancellationToken cancellationToken) => await _repository.UpdateAsync(customer, cancellationToken);
        public async Task<CodeGeassResult<bool>> IsAlreadyExistsNickName(string nickName, CancellationToken cancellationToken)
        {
            return await CodeGeassResultExtension.Run(() => _context.Characters.AnyAsync(c => c.NickName.Equals(nickName), cancellationToken));
        }
    }
}
