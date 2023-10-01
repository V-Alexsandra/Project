using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Repositories.Contracts;

namespace TestTask.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        protected ApplicationDbContext appContext;
        protected DbSet<Order> DbSet;

        public OrderRepository(ApplicationDbContext appContext)
        {
            this.appContext = appContext;
            DbSet = appContext.Set<Order>();
        }

        public async Task<List<Order>> GetOrdersWithNumberOfProductsGreaterThenTenAsync()
        {
            var ordersWithNumberOfProductsGreaterThenTen = await DbSet
                .Where(o => o.Quantity > 10)
                .ToListAsync();

            return ordersWithNumberOfProductsGreaterThenTen;
        }

        public async Task<Order> GetOrderWhithLargestOrderAmountAsync()
        {
            var orderWhithLargestOrderAmount = await DbSet
                .OrderByDescending(o => o.Price * o.Quantity)
                .FirstOrDefaultAsync();

            return orderWhithLargestOrderAmount;
        }
    }
}
