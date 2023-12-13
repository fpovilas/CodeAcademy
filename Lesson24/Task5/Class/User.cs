namespace Task5.Class
{
    internal class User
    {
        public string Name { get; set; }
        public List<Product> ShoppingCart { get; set; }

        public User(string name)
        {
            Name = name;
            ShoppingCart = new List<Product>();
        }

        public void AddProduct(Product product)
        { ShoppingCart.Add(product); }
    }
}
