using TestTask.Models;

namespace TestTask.Repositories.Contracts
{
    public interface IOrderRepository
    {
        public Task<Order> GetOrderWhithLargestOrderAmountAsync();

        public Task<List<Order>> GetOrdersWithNumberOfProductsGreaterThenTenAsync();
    }
}
