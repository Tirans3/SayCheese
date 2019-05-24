using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using SayCheese.ViewModels;

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

            ProductListViewModel vm = new ProductListViewModel
            {
                Products = _productRepository.Products,
                CurrentCategory="CurrentCategory"
            };

            return View(vm); 
            
        }

       
    }
}
