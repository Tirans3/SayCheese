using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SayCheese.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Data
{
    public class ShoppingCart
    {

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public string ShoppingCartId { get; set; }

        private readonly SayDbContext _sayDbContext;

        private ShoppingCart(SayDbContext sayDbContext)
        {
            _sayDbContext = sayDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<SayDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem =
                    _sayDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = amount
                };

                _sayDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount+=amount;
            }
            _sayDbContext.SaveChanges();
        }

        public void RemoveFromCart(Product product)
        {
            var shoppingCartItem =
                    _sayDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);
          
                    _sayDbContext.ShoppingCartItems.Remove(shoppingCartItem);

            _sayDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _sayDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Product)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _sayDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _sayDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _sayDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _sayDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
            return total;
        }

        public void EditAmount(int productId, string sign)
        {
            var shoppingCartItem =
                    _sayDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductId == productId && s.ShoppingCartId == ShoppingCartId);
            if (sign.Equals("plus"))

                shoppingCartItem.Amount++;
            else
               if (shoppingCartItem.Amount != 0)
                shoppingCartItem.Amount--;
            else
                return;

            _sayDbContext.SaveChanges();
        }
    }
}

