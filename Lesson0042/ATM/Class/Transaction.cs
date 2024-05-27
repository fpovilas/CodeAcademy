namespace ATM.Class
{
    internal class Transaction(double amount, string action, DateTime dateTime = default)
    {
        private DateTime TransactionTime { get; set; } = dateTime;
        private double Amount { get; set; } = amount;
        private string Action { get; set; } = action;

        public DateTime GetTransactionTime() => TransactionTime;
        public string GetAction() => Action;
        public double GetAmount() => Amount;

        public override string ToString() => $"{TransactionTime} - {Amount:0.00}€ - {Action}";
        public string ToStringForFile() => $"{TransactionTime.ToFileTime()},{Amount},{Action}";
    }
}
