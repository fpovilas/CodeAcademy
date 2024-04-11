using Atm.Model;

namespace Atm.Interfaces
{
    public interface ITransactionRespository
    {
        void CreateTransaction(Transaction transaction);
        List<Transaction> GetTransactionDetails(string accountNo, string CustomerKey, int limit);
    }
}
