using Asp.Versioning.OData;
using AutoMapper;
using CodeGeass.Api.Filters;
using CodeGeass.KnightmareFrames.Api.Base;
using CodeGeass.KnightmareFrames.Api.Controllers.v1.KnightmareFrames.Requests;
using CodeGeass.KnightmareFrames.Api.Filters;
using CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.CreateKnightmareFrame;
using CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.DeleteKnightmareFrame;
using CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.UpdateKnightmareFrame;
using CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Queries.GetAllKnightmareFrame;
using CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Queries.GetByIdKnightmareFrame;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CodeGeass.KnightmareFrames.Api.Controllers.v1.KnightmareFrames
{
    /// <summary>
    /// Controller responsavel pelo Aggreagate KnightmareFrames
    /// </summary>
    [AllowAnonymous]
    public class KnightmareFramesController: ApiControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public KnightmareFramesController(IMediator mediator, IMapper mapper) : base(mapper)
        {
            _mediator = mediator;
        }

        #region HttpGet
        /// <summary>
        /// Busca todos as armaduras
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/v1/knightmareFrames
        ///
        /// </remarks>
        /// <returns>Uma lista com as armaduras</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ODataValue<List<GetAllKnightmareFrameOutPut>>), StatusCodes.Status200OK)]
        [ProducesResponseBadRequest]
        [ProducesResponseInternalServerError]
        [ODataQueryOptionsValidate]
        public async Task<IActionResult> GetAllAsync(ODataQueryOptions<GetAllKnightmareFrameOutPut> queryOptions, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetAllKnightmareFrameInput(), cancellationToken);
            return await HandleQueryable(output.Result, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Busca uma determinada armadura pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/v1/knightmareFrames/{knightmareFrameId}
        ///
        /// </remarks>
        /// <returns>Retorna uma armadura</returns>
        [HttpGet("{knightmareFrameId}")]
        [ProducesResponseType(typeof(GetByIdKnightmareFrameOutPut), StatusCodes.Status200OK)]
        [ProducesResponseBadRequest]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> GetByIdAsync(Guid knightmareFrameId, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetByIdKnightmareFrameInput() { KnightmareFrameId = knightmareFrameId }, cancellationToken);
            return HandleWithResult<GetByIdKnightmareFrameOutPut>(output.Result);
        }
        #endregion HttpGet

        #region HttpPost
        /// <summary>
        /// Registra uma nova armadura.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/v1/knightmareFrames
        ///
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseBadRequest]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> PostAsync(CreateKnightmareFrameRequest request, CancellationToken cancellationToken)
        {
            var input = _mapper.Map<CreateKnightmareFrameInput>(request);
            var output = await _mediator.Send(input, cancellationToken);
            return HandleWithoutResult(output.Result);
        }
        #endregion HttpPost

        #region HttpPut
        /// <summary>
        /// Atualiza uma armadura pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/v1/knightmareFrames/{knightmareFrameId}
        ///
        /// </remarks>
        [HttpPut("{knightmareFrameId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseBadRequest]
        [ProducesResponseNotFound]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> PutAsync(Guid knightmareFrameId, UpdateKnightmareFrameRequest request, CancellationToken cancellationToken)
        {
            var input = _mapper.Map<UpdateKnightmareFrameInput>(request);
            input.Id = knightmareFrameId;
            var output = await _mediator.Send(input, cancellationToken);
            return HandleWithoutResult(output.Result);
        }
        #endregion HttpPut

        #region HttpDelete
        /// <summary>
        /// Remove uma armadura.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /api/v1/knightmareFrames/{knightmareFrameId}
        ///
        /// </remarks>
        [HttpDelete("{knightmareFrameId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseBadRequest]
        [ProducesResponseNotFound]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> DeleteAsync(Guid knightmareFrameId, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new DeleteKnightmareFrameInput() { KnightmareFrameId = knightmareFrameId }, cancellationToken);
            return HandleWithoutResult(output.Result);
        }
        #endregion HttpDelete
    }
}
