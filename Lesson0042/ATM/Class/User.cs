using ATM.Interface;

namespace ATM.Class
{
    internal class User(string name) : IWritable
    {
        private string Name { get; set; } = name;
        private Account? Account { get; set; } = null;
        private List<Transaction> Transactions { get; set; } = [];

        public Account? GetAccount() => Account;
        public string GetName() => Name;
        public List<Transaction> GetTransactions() => Transactions;

        public void SetAccount(Account acc)
        {
            Account = acc;
            acc.SetUser(this);
        }
        public void SetTransaction(Transaction transaction) => Transactions.Add(transaction);

        public void WriteToFile(string path)
        {
            path = $"{path}{Name}_Transactions.txt";
            using StreamWriter writer = new(path, true);
            writer.WriteLine(Transactions!.LastOrDefault()!.ToStringForFile());
        }

        public void ReadFromFile(string path)
        {
            path = $"{path}{Name}_Transactions.txt";
            Transactions.Clear();

            if (File.Exists(path))
            {
                Read(path);
            }
            else
            {
                File.Create(path).Close();
                Read(path);
            }
        }

        private void Read(string path)
        {
            using StreamReader streamReader = new(path);
            List<string> strings = [.. streamReader.ReadToEnd().Replace("\r\n", ",").Split(',')];
            strings = strings.Where(str => str != string.Empty).ToList();
            for (int i = 0; i < strings.Count; i += 3)
            {
                DateTime time = DateTime.FromFileTime(Convert.ToInt64(strings[i]));
                Transactions.Add(new(Convert.ToDouble(strings[i + 1]), strings[i + 2], time));
            }
        }

        public override string ToString() => $"Name:{Name},Password:{Account?.GetPassword()}," +
            $"Balance:{Account?.GetMoneyInAccount()},CardNumber:{Account?.GetCardNumber()}";

        public string ToStringToFile() => $"{Name},{Account?.GetPassword()}," +
            $"{Account?.GetMoneyInAccount()},{Account?.GetCardNumber()}";
    }
}