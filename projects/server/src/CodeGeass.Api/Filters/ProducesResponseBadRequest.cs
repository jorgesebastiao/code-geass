using CodeGeass.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeGeass.Api.Filters
{
    /// <summary>
    /// Classe responsavel por produzir documentação de resposta de erro de Negocio
    /// </summary>
    public class ProducesResponseBadRequest : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Contrutor padrão
        /// </summary>
        public ProducesResponseBadRequest() : base(typeof(ExceptionPayload), StatusCodes.Status400BadRequest)
        {

        }
    }
}
