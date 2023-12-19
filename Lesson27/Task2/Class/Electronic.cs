namespace Task2.Class
{
    internal class Electronic : Product
    {
        private int Warranty {  get; set; }

        public Electronic(string name, double price, int warranty) : base(name, price)
        {
            Warranty = warranty;
        }

        public int GetWarranty() => Warranty;

        public void SetWarranty(int warranty) { Warranty = warranty; }
    }
}
