using Microsoft.EntityFrameworkCore;
using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SayCheese.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SayDbContext _appDbContext;
        public ProductRepository(SayDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> Products => _appDbContext.Products.Include(c => c.Category);

        public IEnumerable<Product> PreferredProducts => _appDbContext.Products.Where(p => p.IsPreferredProduct).Include(c => c.Category);

        public Product GetProductById(int ProductId) => _appDbContext.Products.FirstOrDefault(p => p.ProductId == ProductId);
    }
}
