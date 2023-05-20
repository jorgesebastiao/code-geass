using CodeGeass.Infra.Extensions;
using MediatR;
using System.Transactions;

namespace CodeGeass.Application.Common
{
    public abstract class BaseInput : IRequest<Output>
    {

    }

    public abstract class BaseCommandInput : BaseInput, IUseTransactionScope
    {
        public TransactionOptions GetTransactionOptions() => new TransactionOptions().Default();
    }

    public abstract class BaseQueryInput : BaseInput
    {

    }

    public interface IAuthenticatedInput
    {
        string LoggedUser { get; set; }
        string LoggedUserMail { get; set; }
    }

    public abstract class BaseAuthenticatedCommandInput : BaseCommandInput, IAuthenticatedInput
    {
        public string LoggedUser { get; set; }
        public string LoggedUserMail { get; set; }
    }

    public abstract class BaseAuthenticatedQueryInput : BaseQueryInput, IAuthenticatedInput
    {
        public string LoggedUser { get; set; }
        public string LoggedUserMail { get; set; }
    }

}
