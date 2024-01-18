namespace ATM.Class
{
    internal class ATM(Account account)
    {
        private Account Account { get; set; } = account;

        public void AddMoney(double amount) => Account.MoneyInAccount += amount;

        public void WithdrawMoney(double amount) => Account.MoneyInAccount -= amount;
    }
}
