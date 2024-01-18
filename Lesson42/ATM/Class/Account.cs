namespace ATM.Class
{
    internal class Account(string pass, double moneyInAccount = 0, string cardNum = "000000000")
    {
        private string CardNumber { get; } = cardNum;
        internal double MoneyInAccount { get; set; } = moneyInAccount;
        private string Password { get; set; } = pass;
        private bool IsBlocked { get; set; } = false;

        public string GetCardNumber() => CardNumber;
        public double GetMoneyInAccount() => MoneyInAccount;
        public string GetPassword() => Password;
        public bool GetIsBlocked() => IsBlocked;

        public void SetIsBlocked() => IsBlocked = true;
    }
}