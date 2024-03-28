using Task1.Model;
using Task1.Repository.Interface;
using Task1.Service.Interface;

namespace Task1.Service
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        // You do not need to define this Field if you using PRIMARY Constructor
        //private readonly IProductRepository productRepository = productRepository;

        public IEnumerable<Product> Get() => productRepository.GetProducts();

        public Result<Product> GetProductByName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
                return Result<Product>.Failure($"Product with {productName} does not exist");
            else
            {
                Product? product = productRepository.GetProductByName(productName);
                return Result<Product>.Success("Product found", product);
            }
        }

        public ResultList<Product> GetByPriceRange(decimal priceMin, decimal priceMax)
        {
            if (priceMin > priceMax)
                return ResultList<Product>.Failure($"Minimum value ({priceMin}) is bigger then maximum value ({priceMax})");
            else
            {
                IEnumerable<Product> products = productRepository.GetByPriceRange(priceMin, priceMax);
                if (products.Any())
                {
                    return ResultList<Product>.Success($"Products between {priceMin:0.##} and {priceMax:0.##} price range has been found", products);
                }
                else { return ResultList<Product>.Failure($"Could not find any products between {priceMin:0.##} and {priceMax:0.##} range"); }
            }
        }

        public Result<Product> Add(Product product)
        {
            if (string.IsNullOrEmpty(product.Name) && product.Price < 0)
                return Result<Product>.Failure("Creation failed");
            else
            {
                productRepository.Add(product);
                return Result<Product>.Success("Product created", product);
            }
        }

        public Result<Product> RemoveByID(int id)
        {
            List<Product> products = productRepository.GetProducts().ToList();
            if (products.Any(p => p.Id == id))
            {
                int index = products.IndexOf(products.FirstOrDefault(p => p.Id == id)!);
                var product = products.FirstOrDefault(p => p.Id == id);
                productRepository.RemoveByID(index);
                return Result<Product>.Success("Product deleted", product);
            }
            else { return Result<Product>.Failure("Deletion failed"); }
        }
    }
}