using e_commerce_api.src.Repositories;
using e_commerce_api.src.Services;
using Microsoft.Extensions.DependencyInjection;

namespace e_commerce_api.src.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddECommercyRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }

        public static IServiceCollection AddECommercyServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}