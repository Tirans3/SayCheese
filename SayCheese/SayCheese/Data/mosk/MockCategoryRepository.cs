using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using System.Collections.Generic;

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
