using Task1.Model;

namespace Task1.Repository.Interface
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product? GetProductByName(string productName);
        public IEnumerable<Product> GetByPriceRange(decimal priceMin, decimal priceMax);
        public void Add(Product product);
        public void RemoveByID(int ID);
    }
}
