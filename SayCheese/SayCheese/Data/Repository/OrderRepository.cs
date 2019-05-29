using SayCheese.Data.Interfaces;
using SayCheese.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayCheese.Data.Repository
{
        public class OrderRepository : IOrderRepository
        {
            private readonly SayDbContext _sayDbContext;
            private readonly ShoppingCart _shoppingCart;


            public OrderRepository(SayDbContext sayDbContext, ShoppingCart shoppingCart)
            {
                _sayDbContext = sayDbContext;
                _shoppingCart = shoppingCart;
            }


            public void CreateOrder(Order order)
            {
                order.OrderPlaced = DateTime.Now;

                _sayDbContext.Orders.Add(order);

                var shoppingCartItems = _shoppingCart.ShoppingCartItems;

                foreach (var Item in shoppingCartItems)
                {
                    var orderDetail = new OrderDetails()
                    {
                        Amount = Item.Amount,
                        ProductId = Item.Product.ProductId,
                        OrderId = order.OrderId,
                        Price = Item.Product.Price
                    };

                    _sayDbContext.OrderDetails.Add(orderDetail);
                }

                _sayDbContext.SaveChanges();
            }
        }
    }

