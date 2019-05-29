using Microsoft.AspNetCore.Mvc;
using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Controllers
{
    public class OrderController:Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
      
        public IActionResult Checkout()
        {
            return View();
        }
        
    }
}
