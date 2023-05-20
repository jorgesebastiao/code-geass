using CodeGeass.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeGeass.Api.Filters
{
    /// <summary>
    /// Classe responsavel por produzir documentação de resposta de erro de Não autorizado
    /// </summary>
    public class ProducesResponseForbidden : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ProducesResponseForbidden() : base(typeof(ExceptionPayload), StatusCodes.Status403Forbidden)
        {
        }
    }
}
