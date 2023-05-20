using System.Transactions;

namespace CodeGeass.Application.Common
{
    public interface IUseTransactionScope
    {
        TransactionOptions GetTransactionOptions();

    }
}
