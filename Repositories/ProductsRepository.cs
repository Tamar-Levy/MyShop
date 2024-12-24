using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        MyShop0331Context _context;

        public ProductsRepository(MyShop0331Context context)
        {
            _context = context;
        }

        //Get
        public async Task<List<Product>> Get(int position,int skip, string? name, int? minPrice, int? maxPrice, int?[]categoryIds)
        {
            var query = _context.Products.Include(c => c.Category).Where(product => (name == null ? (true) : (product.Description.Contains(name)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))).OrderBy(product => product.Price);
            List<Product> products = await query.ToListAsync();
            return products;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
