using SayCheese.Data.Models;
using System.Collections.Generic;

namespace SayCheese.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}


