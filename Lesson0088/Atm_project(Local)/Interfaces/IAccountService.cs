using Atm.Model;

namespace Atm.Interfaces
{
    public interface IAccountService
    {
        public List<Account> CreateAccountWithoutSave(Guid customerKey, float startingBalance = 1000);
        string Transfer(string CustomerKey, string ToAccountNo, float amount);
        public Account GetAccountDetails(string customerKey, string accountNumber);
        Account Withdraw(string CustomerKey, string accountNumber, float amount);
        Account Deposit(string CustomerKey, string accountNumber, float amount);
    }
}
