namespace Task1.Database.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public DateTime TransactionTime { get; set; }
        public double Amount { get; set; }
        public Action TransactionAction { get; set; }
    }

    public enum Action
    {
        Withdraw,
        Deposit
    };
}
