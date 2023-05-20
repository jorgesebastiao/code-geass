using CodeGeass.Core.Data;
using CodeGeass.SharedKernel.Result;

namespace CodeGeass.Characters.Domain.Features.Characters
{
    public interface ICharacterRepository : IAggregateRootRepository<Character>
    {
        Task<CodeGeassResult<Character>> AddAsync(Character customer, CancellationToken cancellationToken);
        Task<CodeGeassResult<Unit>> DeleteAsync(Character customer, CancellationToken cancellationToken);
        Task<CodeGeassResult<IQueryable<Character>>> GetAllAsync();
        Task<CodeGeassResult<Character>> GetByIdAsync(Guid customerId, CancellationToken cancellationToken);
        Task<CodeGeassResult<Character>> UpdateAsync(Character customer, CancellationToken cancellationToken);
        Task<CodeGeassResult<bool>> IsAlreadyExistsNickName(string cpfCnpj, CancellationToken cancellationToken);

    }
}
