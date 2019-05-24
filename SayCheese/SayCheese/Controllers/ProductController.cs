using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;

namespace SayCheese.Controllers
{
    public class ProductController :Controller
    {
       private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;

       public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult List()
        {
              var products = _productRepository.Products;
              return View(products); 
            
        }

       
    }
}
