using Asp.Versioning;
using AutoMapper;
using CodeGeass.Api.Exceptions;
using CodeGeass.Core.Exceptions;
using CodeGeass.SharedKernel.Result;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace CodeGeass.Characters.Api.Base
{
    /// <summary>
    /// Controller base 
    /// </summary>
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// Serviço responsavel pelo mapeamento entre objetos
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Construtor Default
        /// </summary>
        /// <param name="mapper"></param>
        public ApiControllerBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected IActionResult HandleWithoutResult(CodeGeassResult result)
        {
            return result.IsFailure ? HandleFailure(result.Failure) : NoContent();
        }

        protected IActionResult HandleWithResult<TResult>(CodeGeassResult result)
        {
            return result.IsFailure ? HandleFailure(result.Failure) : Ok(((CodeGeassResult<TResult>)result).Success);
        }

        protected async Task<IActionResult> HandleQueryable<TResult>(CodeGeassResult result, ODataQueryOptions<TResult> queryOptions, CancellationToken cancellationToken)
        {
            return await HandleQueryable<TResult, TResult>(result, queryOptions, cancellationToken);
        }

        protected async Task<IActionResult> HandleQueryable<TQueryOptions, TResult>(CodeGeassResult result,
        ODataQueryOptions<TQueryOptions> queryOptions, CancellationToken cancellationToken)
        {
            if (result.IsFailure)
                return this.HandleFailure(result.Failure);

            var queryable = ((CodeGeassResult<IQueryable<TResult>>)result).Success;

            return this.Ok(await this.HandlePageResult(queryable, cancellationToken, queryOptions));
        }

        protected async Task<IActionResult> HandleQueryable<TResult>(CodeGeassResult result, CancellationToken cancellationToken)
        {
            if (result.IsFailure)
                return HandleFailure(result.Failure);

            var queryable = ((CodeGeassResult<IQueryable<TResult>>)result).Success;

            return Ok(await HandlePageResult<TResult, TResult>(queryable, cancellationToken));
        }

        protected async Task<IActionResult> HandleQueryable<TQueryOptions, TResult>(CodeGeassResult<IQueryable<TResult>> result, CancellationToken cancellationToken)
        {
            if (result.IsFailure)
                return HandleFailure(result.Failure);

            return Ok(await HandlePageResult<TQueryOptions, TResult>(result.Success, cancellationToken));
        }

        protected async Task<PageResult> HandlePageResult<TQueryOptions, TResult>
        (IQueryable<TResult> queryable, CancellationToken cancellationToken, ODataQueryOptions<TQueryOptions> queryOptions = null)
        {
            IQueryable queryResults = (queryOptions != null) ? queryOptions.ApplyTo(queryable) : queryable;

            return await RetrieveQueryablePageResult<TResult>(Request, queryResults, cancellationToken);
        }

        private static async Task<PageResult> RetrieveQueryablePageResult<TResult>(HttpRequest request, IQueryable queryable, CancellationToken cancellationToken)
        {
            IQueryable<TResult> queryResults = (IQueryable<TResult>)queryable;
            return new PageResult<TResult>(await queryResults.ToListAsync(cancellationToken),
            request.HttpContext.ODataFeature().NextLink,
            request.HttpContext.ODataFeature().TotalCount);
        }

        protected IActionResult HandleQueryableInMemory<TResult>(CodeGeassResult result,
                ODataQueryOptions<TResult> queryOptions)
        {
            if (result.IsFailure)
                return HandleFailure(result.Failure);

            var queryable = ((CodeGeassResult<IQueryable<TResult>>)result).Success;
            var queryResults = queryOptions.ApplyTo(queryable).Cast<TResult>();

            return Ok(new PageResult<TResult>(queryResults.ToList(), Request.HttpContext.ODataFeature().NextLink, Request.HttpContext.ODataFeature().TotalCount));
        }

        public IActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {

            if (exceptionToHandle is ValidationException)
            {
                var failures = (exceptionToHandle as ValidationException).Errors.Map(_mapper);
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), ExceptionPayload.New(exceptionToHandle, failures));
            }
            var exceptionPayload = ExceptionPayload.New(exceptionToHandle);

            return exceptionToHandle is BusinessException ?
                StatusCode(exceptionPayload.Status.GetHashCode(), exceptionPayload) :
                StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), exceptionPayload);
        }
    }
}
