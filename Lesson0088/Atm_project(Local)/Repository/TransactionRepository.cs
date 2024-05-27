using Atm.Database;
using Atm.Interfaces;
using Atm.Model;

namespace Atm.Repository
{
    public class TransactionRepository : ITransactionRespository
    {
        private readonly AtmContext _context;
        public TransactionRepository(AtmContext context)
        {
            _context = context;
        }
        public void CreateTransaction(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            var newTransaction = new Transaction
            {
                AccountNo = transaction.AccountNo,
                Amount = transaction.Amount,
                Date = DateTime.Now,
                Type = transaction.Type,
            };
            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();
        }
        public List<Transaction> GetTransactionDetails(string accountNo, string CustomerKey, int limit)
        {
            if (String.IsNullOrEmpty(accountNo)) throw new ArgumentNullException(nameof(accountNo));
            if (String.IsNullOrEmpty(CustomerKey)) throw new ArgumentNullException(nameof(CustomerKey));
            return limit > 0 ? _context.Transactions.Where(t => t.AccountNo == accountNo && t.Account.CustomerKey == Guid.Parse(CustomerKey)).Take(limit).ToList()
                : _context.Transactions.Where(t => t.AccountNo == accountNo && t.Account.CustomerKey == Guid.Parse(CustomerKey)).ToList();
        }
    }
}
