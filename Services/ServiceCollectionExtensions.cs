using Homeo_Mart.Interfaces;
using Homeo_Mart.Repositories;

namespace Homeo_Mart.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Add more repositories here in future
            return services;
        }
    }
}
