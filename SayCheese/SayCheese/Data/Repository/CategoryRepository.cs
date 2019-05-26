using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SayDbContext _sayDbContext;
        public CategoryRepository(SayDbContext sayDbContext)
        {
            _sayDbContext = sayDbContext;
        }
        public IEnumerable<Category> Categories => _sayDbContext.Categories; 
    }
}
