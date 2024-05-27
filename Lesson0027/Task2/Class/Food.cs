namespace Task2.Class
{
    internal class Food : Product
    {
        private DateTime ExpirationTime { get; set; }

        public Food(string name, double price, DateTime expirationDate) : base(name, price)
        {
            ExpirationTime = expirationDate;
        }

        public void SetExpirationTime(DateTime expirationTime) { ExpirationTime = expirationTime; }

        public DateTime GetExpirationTime() => ExpirationTime;
    }
}
