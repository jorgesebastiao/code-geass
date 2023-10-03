using Asp.Versioning.OData;
using AutoMapper;
using CodeGeass.Api.Filters;
using CodeGeass.Characters.Api.Base;
using CodeGeass.Characters.Api.Controllers.v1.Characters.Requests;
using CodeGeass.Characters.Api.Filters;
using CodeGeass.Characters.Application.Features.Characters.Commands.UpdateCharacter;
using CodeGeass.Characters.Application.Features.Characters.Queries.GetAllCustomer;
using CodeGeass.Characters.Application.Features.Characters.Queries.GetByIdCharacter;
using CodeGeass.Characters.Application.Features.Customers.Commands.CreateCustomer;
using CodeGeass.Characters.Application.Features.Customers.Commands.DeleteCustomer;
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

        /// <summary>
        /// Busca um determinado personagem pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/v1/characters/{characterId}
        ///
        /// </remarks>
        /// <returns>Retorna um personagem</returns>
        [HttpGet("{characterId}")]
        [ProducesResponseType(typeof(GetByIdCharacterOutPut), StatusCodes.Status200OK)]
        [ProducesResponseBadRequest]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> GetByIdAsync(Guid characterId, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetByIdCharacterInput() { CharacterId = characterId }, cancellationToken);
            return HandleWithResult<GetByIdCharacterOutPut>(output.Result);
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

        #region HttpPut
        /// <summary>
        /// Atualiza um personagem pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/v1/characters/{characterId}
        ///
        /// </remarks>
        [HttpPut("{characterId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseBadRequest]
        [ProducesResponseNotFound]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> PutAsync(Guid characterId, UpdateCharacterRequest request, CancellationToken cancellationToken)
        {
            var input = _mapper.Map<UpdateCharacterInput>(request);
            input.Id = characterId;
            var output = await _mediator.Send(input, cancellationToken);
            return HandleWithoutResult(output.Result);
        }
        #endregion HttpPut

        #region HttpDelete
        /// <summary>
        /// Remove um personagem.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /api/v1/characters/{characterId}
        ///
        /// </remarks>
        [HttpDelete("{characterId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseBadRequest]
        [ProducesResponseNotFound]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> DeleteAsync(Guid characterId, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new DeleteCharacterInput() { CharacterId = characterId }, cancellationToken);
            return HandleWithoutResult(output.Result);
        }
        #endregion HttpDelete
    }
}
