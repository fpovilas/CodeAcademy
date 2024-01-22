using ATM.Interface;

namespace ATM.Class
{
    internal class User(string name, Account account) : IWritable
    {
        private string Name { get; set; } = name;
        private Account Account { get; set; } = account;
        private List<Transaction> Transactions { get; set; } = [];

        public Account GetAccount() => Account;
        public string GetName() => Name;
        public List<Transaction> GetTransactions() => Transactions;

        public void SetTransaction(Transaction transaction) => Transactions.Add(transaction);

        public void WriteToFile(string path)
        {
            string dataToWrite = $"{Name},{Account.GetPassword()}," +
                          $"{Account.GetMoneyInAccount()},{Account.GetCardNumber()}";
            using StreamWriter streamWriter = new(path);
                streamWriter.Write(dataToWrite);
            Console.WriteLine($"Name:{Name},Pass:{Account.GetPassword()},Balance:{Account.GetMoneyInAccount()},CardNumber:{Account.GetCardNumber()}");
            Console.WriteLine("Data has been written.");
            Console.ReadKey(true);
        }
    }
}