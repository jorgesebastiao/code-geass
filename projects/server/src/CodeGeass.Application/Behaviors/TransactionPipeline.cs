using CodeGeass.Application.Common;
using MediatR;
using System.Transactions;

namespace CodeGeass.Application.Behaviors
{
    /// <summary>
    /// Pipeline responsavel pelo controle de transações com o Banco de dados
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// see=https://medium.com/swlh/transaction-management-with-mediator-pipelines-in-asp-net-core-39317a19bb8d
    public class TransactionPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IUseTransactionScope
        where TResponse : Output
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var transactionOptions = request.GetTransactionOptions();

            using (var transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                        TransactionScopeAsyncFlowOption.Enabled))
            {
                // handle request handler
                var response = await next();

                if (response.Result.IsFailure)
                {
                    transaction.Dispose();
                    return response;
                }

                // complete database transaction
                transaction.Complete();

                return response;
            }
        }
    }
}
