using Atm.Database;
using Atm.Interfaces;
using Atm.Model;

namespace Atm.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AtmContext _context;
        private readonly ITransactionService _transactionService;

        public AccountRepository(AtmContext context, ITransactionService transactionService)
        {
            _context = context;
            _transactionService = transactionService;
        }

        public string Transfer(string CustomerKey, string ToAccountNo, float amount)
        {
            if (string.IsNullOrEmpty(CustomerKey)) throw new ArgumentNullException(nameof(CustomerKey));
            if (string.IsNullOrEmpty(ToAccountNo)) throw new ArgumentNullException(nameof(ToAccountNo));
            if (amount <= 0) throw new Exception("Invalid amount");
            var account = _context.Accounts.FirstOrDefault(a => a.CustomerKey == Guid.Parse(CustomerKey)) ?? throw new Exception("Invalid account");
            var toAccount = _context.Accounts.FirstOrDefault(a => a.Number == ToAccountNo) ?? throw new Exception("Invalid recipient account");
            if (account.Balance < amount) throw new Exception("Insufficient balance");
            account.Balance -= amount;
            toAccount.Balance += amount;
            _context.SaveChanges();
            return "Transaction successful";
        }

        public void CreateAccount(List<Account> accounts)
        {
            _context.Accounts.AddRange(accounts);
            _context.SaveChanges();
        }

        public Account GetAccountDetails(string customerKey, string accountNumber)
        {
            var account = _context.Accounts.Where(account => account.CustomerKey == Guid.Parse(customerKey) && account.Number == accountNumber).FirstOrDefault();
            return account ?? throw new Exception("Failed to get data");
        }

        public Account Withdraw(string CustomerKey, string accountNumber, float amount)
        {
            if (string.IsNullOrEmpty(CustomerKey)) throw new ArgumentNullException(nameof(CustomerKey));
            if (string.IsNullOrEmpty(accountNumber)) throw new ArgumentNullException(nameof(accountNumber));
            if (amount <= 0) throw new Exception("Invalid amount");
            var account = _context.Accounts.FirstOrDefault(a => a.CustomerKey == Guid.Parse(CustomerKey) && a.Number == accountNumber) ?? throw new Exception("Invalid account");
            if (account.Balance < amount) throw new Exception("Insufficient balance");
            account.Balance -= amount;
            var transaction = new Transaction
            {
                AccountNo = account.Number,
                Amount = amount,
                Type = "Withdraw",
                Account = account,
                Date = DateTime.Now
            };
            _transactionService.CreateTransaction(transaction);
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return account;
        }

        public Account Deposit(string CustomerKey, string accountNumber, float amount)
        {
            if (string.IsNullOrEmpty(CustomerKey)) throw new ArgumentNullException(nameof(CustomerKey));
            if (string.IsNullOrEmpty(accountNumber)) throw new ArgumentNullException(nameof(accountNumber));
            if (amount <= 0) throw new Exception("Invalid amount");
            var account = _context.Accounts.FirstOrDefault(a => a.CustomerKey == Guid.Parse(CustomerKey) && a.Number == accountNumber) ?? throw new Exception("Invalid account");
            account.Balance += amount;
            var transaction = new Transaction
            {
                AccountNo = account.Number,
                Amount = amount,
                Type = "Deposit",
                Account = account,
                Date = DateTime.Now
            };
            _transactionService.CreateTransaction(transaction);
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return account;
        }
    }
}
