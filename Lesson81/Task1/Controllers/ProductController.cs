using Lesson81.Model;
using Lesson81.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Lesson81.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ILogger<ProductController> logger, IProductService productService) : ControllerBase
    {
        private readonly IProductService productService = productService;

        private readonly ILogger<ProductController> logger = logger;

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get() => productService.Get();

        [HttpPost]
        [Route("/AddProduct")]
        public Result<Product> Add(Product product)
        {
            Result<Product> result = productService.Add(product);
            return result;
        }

        [HttpDelete]
        [Route("/RemoveByID/{id}")]
        public Result<Product> Delete(int id)
        {
            Result<Product> productToRemove = productService.RemoveByID(id);
            return productToRemove;
        }
    }
}