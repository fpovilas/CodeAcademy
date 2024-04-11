using Atm.Interfaces;
using Atm.Model;

namespace Atm.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRespository _transactionRepository;

        public TransactionService(ITransactionRespository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void CreateTransaction(Transaction transaction)
        {
            _transactionRepository.CreateTransaction(transaction);
        }

        public List<Transaction> GetTransactionDetails(string accountNo, string CustomerKey, int limit)
        {
            return _transactionRepository.GetTransactionDetails(accountNo, CustomerKey, limit);
        }
    }
}
