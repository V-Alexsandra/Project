using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Repositories.Contracts;
using TestTask.Repositories.Implementation;
using TestTask.Services.Common;
using TestTask.Services.Interfaces;

namespace TestTask.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
