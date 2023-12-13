namespace Task4.Class
{
    internal class Bank
    {
        public string Name { get; set; }
        public List<Account> Account { get; set; }

        public Bank(string name)
        {
            Name = name;
            Account = new List<Account>();
        }

        public void CreateAccount(string owner, double balance)
        {
            Account.Add(new Account(owner, balance));
        }
    }
}
