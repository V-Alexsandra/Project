using TestTask.Models;
using TestTask.Repositories.Contracts;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Common
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUser()
        {
            return _userRepository.GetUserWhithLargestNumberOfOrdersAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return _userRepository.GetInaсtiveUserAsync();
        }
    }
}
