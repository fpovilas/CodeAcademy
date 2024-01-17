namespace ATM.Class
{
    internal class User(string name, Account account, string pass)
    {
        private string Name { get; set; } = name;
        private Account Account { get; set; } = account;
        private string Password { get; set; } = pass;
    }
}
