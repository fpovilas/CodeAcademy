using Task1.Data.Interface;
using Task1.Model;
using Task1.Repository.Interface;

namespace Task1.Repository
{
    public class ProductRepository(IProductData productData) : IProductRepository
    {
        // You do not need to define this Field if you using PRIMARY Constructor
        private readonly IProductData productData = productData;

        public IEnumerable<Product> GetProducts() => productData.Products;

        public Product? GetProductByName(string productName) => productData.Products.FirstOrDefault(x => x.Name == productName);

        public IEnumerable<Product> GetByPriceRange(decimal priceMin, decimal priceMax) => productData.Products.Where(p => p.Price >= priceMin && p.Price <= priceMax);

        public void Add(Product product) => productData.Products.Add(product);

        public void RemoveByID(int id) => productData.Products.RemoveAt(id);
    }
}
