using Microsoft.AspNetCore.Mvc;
using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using SayCheese.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SayCheese.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.Products.OrderBy(p => p.ProductId);
                currentCategory = "All products";
            }
            else
            {
                if (string.Equals("Cheese", _category, StringComparison.OrdinalIgnoreCase))
                    products = _productRepository.Products.Where(p => p.Category.CategoryName.Equals("Cheese")).OrderBy(p => p.Name);
                else
                    products = _productRepository.Products.Where(p => p.Category.CategoryName.Equals("Chutney")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            var productsListViewModel=new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            };
            return View(productsListViewModel);
            
        }

        public ViewResult Details(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(d => d.ProductId == productId);
            if (product == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(product);
        }

    }
}
