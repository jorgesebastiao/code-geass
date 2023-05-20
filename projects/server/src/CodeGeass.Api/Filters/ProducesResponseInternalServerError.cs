using CodeGeass.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeGeass.Api.Filters
{
    /// <summary>
    /// Classe responsavel por produzir documentação de resposta de erro interno
    /// </summary>
    public class ProducesResponseInternalServerError : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ProducesResponseInternalServerError() : base(typeof(ExceptionPayload), StatusCodes.Status500InternalServerError)
        {
        }
    }
}
