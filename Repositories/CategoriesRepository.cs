using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        MyShop0331Context _context;

        public CategoriesRepository(MyShop0331Context context)
        {
            _context = context;
        }

        //Get
        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        // GetById
        public async Task<Category> GetById(int id)
        {
            //List<Product> allProducts = await _context.Products.Include(c => c.Category).ToListAsync<Product>();
            Category categoryFound = await _context.Categories.FirstOrDefaultAsync(category => category.CategoryId == id);
            if (categoryFound != null)// return it anyway, if it's null- will return null.
                return categoryFound;
            return null;
        }
    }
}
