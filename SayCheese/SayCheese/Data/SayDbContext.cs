using Microsoft.EntityFrameworkCore;
using SayCheese.Data.Models;

namespace SayCheese.Data
{
    public class SayDbContext : DbContext
    {
        public SayDbContext(DbContextOptions<SayDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
