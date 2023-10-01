using TestTask.Models;

namespace TestTask.Repositories.Contracts
{
    public interface IUserRepository
    {
        public Task<User> GetUserWhithLargestNumberOfOrdersAsync();

        public Task<List<User>> GetInaсtiveUserAsync();
    }
}
