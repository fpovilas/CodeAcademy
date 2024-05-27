using Atm.Model;

namespace Atm.Interfaces
{
    public interface ITransactionService
    {
        void CreateTransaction(Transaction transaction);
        List<Transaction> GetTransactionDetails(string accountNo, string CustomerKey, int limit);
    }
}
