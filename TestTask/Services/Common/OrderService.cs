using TestTask.Models;
using TestTask.Repositories.Contracts;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Common
{
    public class OrderService : IOrderService
    {
        protected readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Order> GetOrder()
        {
            return _orderRepository.GetOrderWhithLargestOrderAmountAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return _orderRepository.GetOrdersWithNumberOfProductsGreaterThenTenAsync();
        }
    }
}
