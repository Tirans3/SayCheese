﻿using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Data.mosk
{
    public class MockProductRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product
                    {
                        Name = "Brie",
                        Price = 7.95M,
                        ShortDescription = "The most widely consumed alcohol",
                        LongDescription = "Beer is the world's oldest[1][2][3] and most widely consumed[4] alcoholic drink; it is the third most popular drink overall, after water and tea.[5] The production of beer is called brewing, which involves the fermentation of starches, mainly derived from cereal grains—most commonly malted barley, although wheat, maize (corn), and rice are widely used.[6] Most beer is flavoured with hops, which add bitterness and act as a natural preservative, though other flavourings such as herbs or fruit may occasionally be included. The fermentation process causes a natural carbonation effect, although this is often removed during processing, and replaced with forced carbonation.[7] Some of humanity's earliest known writings refer to the production and distribution of beer: the Code of Hammurabi included laws regulating beer and beer parlours.",
                        Category = _categoryRepository.Categories.ElementAt(0),
                        ImageUrl = "https://scontent.fevn6-2.fna.fbcdn.net/v/t45.5328-9/16633416_972246206210566_3095718616281120768_n.jpg?_nc_cat=109&_nc_ht=scontent.fevn6-2.fna&oh=e813a4a887601c1d30f0bf0dd05746b0&oe=5D934E48",
                        InStock = true,
                        IsPreferredProduct = true,
                        ImageThumbnailUrl = "https://scontent.fevn6-2.fna.fbcdn.net/v/t45.5328-9/16633416_972246206210566_3095718616281120768_n.jpg?_nc_cat=109&_nc_ht=scontent.fevn6-2.fna&oh=e813a4a887601c1d30f0bf0dd05746b0&oe=5D934E48"
                    }


                };


            }
        }
             public IEnumerable<Product> PreferredProducts { get; }

              public Product GetProductById(int productId)
              {
               throw new NotImplementedException();
              }
        }
    }
    



