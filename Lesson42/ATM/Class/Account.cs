namespace ATM.Class
{
    internal class Account(double moneyInAccount = 0)
    {
        private Guid CardNumber { get; } = Guid.NewGuid();
        private double MoneyInAccount { get; set; } = moneyInAccount;

        private Guid GetCardNumber() => CardNumber;

        private double GetMoneyInAccount() => MoneyInAccount;

        private void AddMoney(double amount) => MoneyInAccount += amount;

        private void WithdrawMoney(double amount) => MoneyInAccount -= amount;
    }
}
