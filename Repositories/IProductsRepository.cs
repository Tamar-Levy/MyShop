using Entities;

namespace Repositories
{
    public interface IProductsRepository
    {
        Task<Product> AddProduct(Product product);
        Task<List<Product>> Get();
    }
}