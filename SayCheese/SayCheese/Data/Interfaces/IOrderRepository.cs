using SayCheese.Data.Models;

namespace SayCheese.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
