using Microsoft.AspNetCore.Mvc;
using SayCheese.Data;
using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using SayCheese.ViewModels;
using System.Linq;

namespace SayCheese.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
        [HttpPost]
        public RedirectToActionResult AddToShoppingCart(int productId,int count)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductId ==productId );
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, count);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }

    }
}