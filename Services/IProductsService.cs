using Entities;

namespace Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}