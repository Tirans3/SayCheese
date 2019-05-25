using Microsoft.EntityFrameworkCore;
using SayCheese.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Data
{
    public class SayDbContext:DbContext
    {
        public SayDbContext(DbContextOptions<SayDbContext> options):base(options)
        {
        }
        public DbSet<Product> Prosucts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
