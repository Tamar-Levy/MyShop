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
        public async Task<List<Product>> Get()
        {
            List<Category> allCategories = await _context.Categories.Include(c => c.Products).ToListAsync<Category>();
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
