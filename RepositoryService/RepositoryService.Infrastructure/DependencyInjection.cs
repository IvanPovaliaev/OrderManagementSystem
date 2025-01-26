using Microsoft.Extensions.DependencyInjection;
using RepositoryService.Domain.Interfaces;
using RepositoryService.Infrastructure.Persistence.Repositories;

namespace RepositoryService.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the dependency injection container
        /// </summary>
        /// <param name="services">Current service collection</param>
        /// <returns>Current service collection with new Infrastructure services</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            return services;
        }
    }
}
