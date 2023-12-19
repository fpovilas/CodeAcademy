namespace Task2.Class
{
    internal class Product
    {
        private string Name { get; set; }
        private double Price { get; set; }

        public Product (string name, double price)
        {
            Name = name;
            Price = price;
        }

        public void SetName(string name) { Name = name; }
        
        public void SetPrice(double price) { Price = price; }

        public string GetName() => Name;

        public double GetPrice() => Price;
    }
}
