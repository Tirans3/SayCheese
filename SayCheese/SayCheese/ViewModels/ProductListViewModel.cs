using SayCheese.Data.Models;
using System.Collections.Generic;

namespace SayCheese.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}
