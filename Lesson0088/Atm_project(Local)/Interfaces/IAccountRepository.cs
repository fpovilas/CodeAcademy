using Atm.Model;

namespace Atm.Interfaces
{
    public interface IAccountRepository
    {
        string Transfer(string CustomerKey, string ToAccountNo, float amount);
        public void CreateAccount(List<Account> accounts);
        public Account GetAccountDetails(string customerKey, string accountNumber);
        Account Withdraw(string CustomerKey, string accountNumber, float amount);
        Account Deposit(string CustomerKey, string accountNumber, float amount);
    }
}
