using Task1.Data.Interface;
using Task1.Model;

namespace Task1.Data
{
    public class ProductData : IProductData
    {
        public List<Product> Products { get; } =
            [
                new Product
                {
                    Id = 1,
                    Name = "Chips",
                    Price = 0.99m,
                },
                new Product
                {
                    Id = 2,
                    Name = "Orange",
                    Price = 0.29m,
                },
                new Product
                {
                    Id = 3,
                    Name = "Dragon Fruit",
                    Price = 3.99m,
                }
            ];
    }
}