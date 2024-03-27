using Lesson81.Model;
using Lesson81.Service.Interface;

namespace Lesson81.Service
{
    public class ProductService : IProductService
    {
        private static List<Product> products =
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

        public IEnumerable<Product> Get() => products;

        public Result<Product> Add(Product product)
        {
            if (string.IsNullOrEmpty(product.Name) && product.Price < 0)
                return Result<Product>.Failure("Creation failed");
            else
            {
                products.Add(product);
                return Result<Product>.Success("Product created", product);
            }
        }

        public Result<Product> RemoveByID(int id)
        {
            if(products.Any(p => p.Id == id))
            {
                int index = products.IndexOf(products.FirstOrDefault(p => p.Id == id)!);
                var product = products.FirstOrDefault(p => p.Id == id);
                products.RemoveAt(index);
                return Result<Product>.Success("Product deleted", product);
            } else { return Result<Product>.Failure("Deletion failed"); }
        }
    }
}