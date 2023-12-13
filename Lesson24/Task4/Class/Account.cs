namespace Task4.Class
{
    internal class Account
    {
        public string Owner { get; set; }
        public double Balance { get; set; }

        public Account(string owner, double balance)
        {
            Owner = owner;
            Balance = balance;
        }

        public void ChangeBalance(double balance)
        {
            Balance = balance;
        }
    }
}
