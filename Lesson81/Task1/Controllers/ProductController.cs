using Task1.Model;
using Task1.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ILogger<ProductController> logger, IProductService productService) : ControllerBase
    {
        // You can not define this Field if you using PRIMARY Constructor
        // private readonly IProductService productService = productService;

        private readonly ILogger<ProductController> logger = logger;

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get() => productService.Get();

        [HttpGet("/GetProductByName/{productName}")]
        public Result<Product> GetProductByName(string productName) => productService.GetProductByName(productName);

        [HttpGet("GetProductsByPrice/{priceMin}-{priceMax}")]
        public ResultList<Product> GetByPriceRange(decimal priceMin, decimal priceMax) => productService.GetByPriceRange(priceMin, priceMax);

        [HttpPost]
        [Route("/AddProduct")]
        public Result<Product> Add(Product product) => productService.Add(product);

        [HttpDelete]
        [Route("/RemoveByID/{id}")]
        public Result<Product> Delete(int id) => productService.RemoveByID(id);
    }
}