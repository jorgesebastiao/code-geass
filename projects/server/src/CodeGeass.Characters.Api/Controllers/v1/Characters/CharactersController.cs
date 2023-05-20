using Asp.Versioning.OData;
using AutoMapper;
using CodeGeass.Api.Filters;
using CodeGeass.Characters.Api.Base;
using CodeGeass.Characters.Api.Controllers.v1.Characters.Requests;
using CodeGeass.Characters.Api.Filters;
using CodeGeass.Characters.Application.Features.Characters.Queries.GetAllCustomer;
using CodeGeass.Characters.Application.Features.Customers.Commands.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CodeGeass.Characters.Api.Controllers.v1.Characters
{
    /// <summary>
    /// Controller responsavel pelo Aggreagate Clientes
    /// </summary>
    [AllowAnonymous]
    public class CharactersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public CharactersController(IMediator mediator, IMapper mapper) : base(mapper)
        {
            _mediator = mediator;
        }

        #region HttpGet
        /// <summary>
        /// Busca todos os personagens
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/v1/characters
        ///
        /// </remarks>
        /// <returns>Uma lista com os personagens</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ODataValue<List<GetAllCharacterOutPut>>), StatusCodes.Status200OK)]
        [ProducesResponseBadRequest]
        [ProducesResponseInternalServerError]
        [ODataQueryOptionsValidate]
        public async Task<IActionResult> GetAllAsync(ODataQueryOptions<GetAllCharacterOutPut> queryOptions, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetAllCharacterInput(), cancellationToken);
            return await HandleQueryable(output.Result, queryOptions, cancellationToken);
        }
        #endregion HttpGet

        #region HttpPost
        /// <summary>
        /// Registra um  novo personagem.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/v1/characters
        ///
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseBadRequest]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> PostAsync(CreateCharacterRequest request, CancellationToken cancellationToken)
        {
            var input = _mapper.Map<CreateCharacterInput>(request);
            var output = await _mediator.Send(input, cancellationToken);
            return HandleWithoutResult(output.Result);
        }
        #endregion HttpPost
    }
}
