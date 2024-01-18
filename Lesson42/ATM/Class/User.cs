namespace ATM.Class
{
    internal class User(string name, Account account)
    {
        private string Name { get; set; } = name;
        private Account Account { get; set; } = account;

        public Account GetAccount() => Account;
        public string GetName() => Name;
    }
}