using System.Transactions;

namespace CodeGeass.Infra.Extensions
{
    public static class TransactionsOptionsExtensions
    {
        public static TransactionOptions Default(this TransactionOptions transaction)
        {
            return new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.MaxValue,
            };
        }
    }
}
