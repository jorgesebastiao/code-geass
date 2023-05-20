
using CodeGeass.Core.DomainObjects;
using CodeGeass.SharedKernel.Result;

namespace CodeGeass.SharedKernel.FactoryPattern
{
    /// <summary>
    /// Interface que define o método de criação de uma entidade com base num command
    /// </summary>
    /// <typeparam name="TEntity">Entidade em questão</typeparam>
    public interface IFactory<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Este método deve criar a entidade
        /// </summary>
        /// <typeparam name="TCommand">Tipo generico para o handler</typeparam>
        /// <param name="mapFunc">Função de mapeamento</param>
        /// <param name="command">Command do handler</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Retorna a entidade criada</returns>
        Task<CodeGeassResult<TEntity>> CreateAsync<TCommand>(Func<TCommand, TEntity> mapFunc, TCommand command, CancellationToken cancellationToken);
    }
}
