using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Data.mosk
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories =>

            new List<Category>
            {
               new Category { CategoryName = "Cheese", Description = "All Cheese" },
               new Category { CategoryName = "Chutney", Description = "All Chutney" }
            };
   

    }
}
