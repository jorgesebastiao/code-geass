using CodeGeass.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeGeass.Api.Filters
{
    /// <summary>
    /// Classe responsavel por produzir documentação de resposta de registro não encontrado
    /// </summary>
    public class ProducesResponseNotFound : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ProducesResponseNotFound() : base(typeof(ExceptionPayload), StatusCodes.Status404NotFound)
        {
        }
    }
}
