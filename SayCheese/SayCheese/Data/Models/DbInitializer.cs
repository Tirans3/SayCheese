using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SayDbContext>();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(Categories.Select(c => c.Value));
                }

                if (!context.Products.Any())
                {
                    context.AddRange
                    (
                        new Product
                        {
                            Name = "Le Blue",
                            Price = 2.00M,
                            ShortDescription = "The most widely consumed Cheese",
                            LongDescription = "The most widely consumed Cheese",
                            Category = Categories["Cheese"],
                            ImageUrl = "https://www.menu.am/resources/default/img/restaurant_products/big/1500535757-7529.jpeg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://www.menu.am/resources/default/img/restaurant_products/big/1500535757-7529.jpeg"
                        },
                        new Product
                        {
                            Name = "Chutney",
                            Price = 2.30M,
                            ShortDescription = "Cheese Board Chutney",
                            LongDescription = "Our extra fruity Cheese Board Chutney is made with Bramley apples, raisins and walnuts. Cheese Board Chutney is a luxury accompaniment to any cheese board· Why not enjoy Cheese Board Chutney with cold meats and pork pies too?",
                            Category = Categories["Chutney"],
                            ImageUrl = "https://www.menu.am/resources/default/img/restaurant_products/big/1500535757-7529.jpeg",
                            InStock = true,
                            IsPreferredProduct = false,
                            ImageThumbnailUrl = "https://www.menu.am/resources/default/img/restaurant_products/big/1500535757-7529.jpeg"
                        }


                       );
                }

                context.SaveChanges();
            }
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Cheese", Description="All Cheese Products" },
                        new Category { CategoryName = "Chutney", Description="All Chunety Products" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
    

