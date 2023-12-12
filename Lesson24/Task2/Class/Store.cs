namespace Task2.Class
{
    internal class Store
    {
        public int YearOfOpening { get; set; }
        public List<string> ProductNames { get; set; }
        public string StoreName { get; set; }

        public Store(string storeName, int yearOfOpening, List<string> productNames)
        {
            StoreName = storeName;
            YearOfOpening = yearOfOpening;
            ProductNames = productNames;
        }

        public void PrintStoreProducts()
        {
            foreach (string product in ProductNames)
            {
                Console.WriteLine($"{StoreName} {YearOfOpening} - {product}");
            }
        }
    }
}
