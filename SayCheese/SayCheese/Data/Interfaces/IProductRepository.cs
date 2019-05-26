using SayCheese.Data.Models;
using System.Collections.Generic;

namespace SayCheese.Data.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> PreferredProducts { get; }
        Product GetProductById(int productId);

    }
}
