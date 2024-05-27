using Task1.Model;

namespace Task1.Service.Interface
{
    public interface IProductService
    {
        public IEnumerable<Product> Get();
        public Result<Product> GetProductByName(string productName);
        public ResultList<Product> GetByPriceRange(decimal priceMin, decimal priceMax);
        public Result<Product> Add(Product product);
        public Result<Product> RemoveByID(int id);
    }
}
