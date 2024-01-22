namespace ATM.Class
{
    internal class Account(string pass, double moneyInAccount = 0, string cardNum = "000000000")
    {
        private string CardNumber { get; } = cardNum;
        private double MoneyInAccount { get; set; } = moneyInAccount;
        private string Password { get; set; } = pass;
        private bool IsBlocked { get; set; } = false;

        public string GetCardNumber() => CardNumber;
        public double GetMoneyInAccount() => MoneyInAccount;
        public string GetPassword() => Password;
        public bool GetIsBlocked() => IsBlocked;

        public void SetIsBlocked() => IsBlocked = true;

        public void AddMoney(double amount) => MoneyInAccount += amount;

        public void WithdrawMoney(double amount)
        {
            if (amount > 1000) { Console.WriteLine("Maximum Withdrawal amount is 1000€"); }
            else if (MoneyInAccount < 0 || MoneyInAccount < amount)
                Console.WriteLine($"Can't withdraw {amount} you have only {MoneyInAccount}");
            else { MoneyInAccount -= amount; }
        }

        public void DepositMoney(double amount)
        {
            if (amount > 1000) { Console.WriteLine("Maximum Deposit amount is 1000€"); }
            else { MoneyInAccount += amount; }
        }
    }
}