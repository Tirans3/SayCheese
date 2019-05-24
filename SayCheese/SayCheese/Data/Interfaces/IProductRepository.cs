using SayCheese.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Data.Interfaces
{
    interface IProductRepository
    {
            IEnumerable<Product> Products { get; }
            IEnumerable<Product> PreferredProducts { get; }
            Product GetProductById(int productId);

    }
}
