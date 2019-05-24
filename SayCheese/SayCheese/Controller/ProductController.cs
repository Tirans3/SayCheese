using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;

namespace SayCheese.Controller
{
    public class ProductController : ControllerBase
    {
        private  IProductRepository _productRepository;
        private  ICategoryRepository _categoryRepository;

       internal ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult List()
        {
              var product = _productRepository.Products;
              return View(product); 
            
        }
    }
}
