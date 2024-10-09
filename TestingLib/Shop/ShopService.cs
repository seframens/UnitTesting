using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLib.Shop
{
    public class ShopService
    {
        private readonly INotificationService _notificationService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public ShopService(ICustomerRepository customerRepository, IOrderRepository orderRepository, INotificationService notificationService)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _notificationService = notificationService;
        }

        public void CreateOrder(Order order)
        {
            if (!(_orderRepository.GetOrderById(order.Id) == null)) throw new ArgumentException("Order with current id already exists");
            _orderRepository.AddOrder(order);
            _notificationService.SendNotification(order.Customer.Email, $"Order {order.Id} created for customer {order.Customer.Name} total price {order.Amount}");
        }

        public string GetCustomerInfo(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            var orders = _orderRepository.GetOrders().Where(o=>o.Customer == customer).ToList();
            return "Customer " + customer.Name + " has " + orders.Count + " orders";
        }
    }
}
