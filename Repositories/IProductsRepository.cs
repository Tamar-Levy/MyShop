using Entities;

namespace Repositories
{
    public interface IProductsRepository
    {
        Task<Product> AddProduct(Product product);
        Task<List<Product>> Get(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}