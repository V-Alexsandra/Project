using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Repositories.Contracts;

namespace TestTask.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        protected ApplicationDbContext appContext;
        protected DbSet<User> DbSet;

        public UserRepository(ApplicationDbContext appContext)
        {
            this.appContext = appContext;
            DbSet = appContext.Set<User>();
        }

        public async Task<User> GetUserWhithLargestNumberOfOrdersAsync()
        {
            var userWithLargestNumberOfOrders = await DbSet
               .Join(
                   appContext.Orders,
                   user => user.Id,
                   order => order.UserId,
                   (user, order) => new
                   {
                       User = user,
                       Order = order
                   }
               )
               .GroupBy(x => x.User)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .FirstOrDefaultAsync();

            return userWithLargestNumberOfOrders;
        }

        public async Task<List<User>> GetInaсtiveUserAsync()
        {
            var inactiveUser = await DbSet
                .Where(u => u.Status == UserStatus.Inactive)
                .ToListAsync();

            return inactiveUser;
        }
    }
}
