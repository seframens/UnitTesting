using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLib.Shop
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        void AddOrder(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
        Order GetOrderById(int id);
    }
}
