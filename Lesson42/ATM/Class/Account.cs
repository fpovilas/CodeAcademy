namespace ATM.Class
{
    internal class Account(string pass, double moneyInAccount = 0, string cardNum = "000000000")
    {
        private string CardNumber { get; } = cardNum;
        private double MoneyInAccount { get; set; } = moneyInAccount;
        private string Password { get; set; } = pass;
        private bool IsBlocked { get; set; } = false;
        private User? User { get; set; } = null;

        private readonly string _pathToTransaction = @"D:\Projektai\Programavimas\CodeAcademy\Lesson42\ATM\DB\Transactions\";

        public string GetCardNumber() => CardNumber;
        public double GetMoneyInAccount() => MoneyInAccount;
        public string GetPassword() => Password;
        public bool GetIsBlocked() => IsBlocked;
        public User? GetUser() => User;

        public void SetIsBlocked() => IsBlocked = true;
        public void SetUser(User usr) => User = usr;

        public bool WithdrawMoney(double amount)
        {
            if (amount > 1000)
            { 
                Console.WriteLine("Maximum Withdrawal amount is 1000€.");
                return false;
            }
            else if (MoneyInAccount < 0 || MoneyInAccount < amount)
            {
                Console.WriteLine($"Can't withdraw {amount}€. You have only {MoneyInAccount}€.");
                return false;
            }
            else if (amount < 0)
            {
                Console.WriteLine("You cannot withdraw negative amount.");
                return false;
            }
            else
            { 
                MoneyInAccount -= amount;
                User!.SetTransaction(new Transaction(amount, "Withdraw", DateTime.Now));
                User!.WriteToFile(_pathToTransaction);
                return true;
            }
        }

        public bool DepositMoney(double amount)
        {
            if (amount > 1000)
            {
                Console.WriteLine("Maximum Deposit amount is 1000€.");
                return false;
            }
            else if (amount < 0)
            {
                Console.WriteLine("You cannot deposit negative amount.");
                return false;
            }
            else
            {
                MoneyInAccount += amount;
                User!.SetTransaction(new Transaction(amount, "Deposit", DateTime.Now));
                User!.WriteToFile(_pathToTransaction);
                return true;
            }
        }
    }
}