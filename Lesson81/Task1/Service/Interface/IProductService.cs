using Lesson81.Model;

namespace Lesson81.Service.Interface
{
    public interface IProductService
    {
        public IEnumerable<Product> Get();
        public Result<Product> Add(Product product);
        public Result<Product> RemoveByID(int id);
    }
}
