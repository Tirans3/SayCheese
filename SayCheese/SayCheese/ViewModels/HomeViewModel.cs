using SayCheese.Data.Models;
using System.Collections.Generic;

namespace SayCheese.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> PreferredProducts  { get; set; }
    }
}
