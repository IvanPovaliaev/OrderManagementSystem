using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryService.Application.Interfaces.MessageBrokerConsumers;
using RepositoryService.Domain.Interfaces;
using RepositoryService.Infrastructure.Host.Services;
using RepositoryService.Infrastructure.Persistence.Repositories;
using RepositoryService.Infrastructure.RabbitMQ;
using RepositoryService.Infrastructure.RabbitMQ.Consumers;

namespace RepositoryService.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the dependency injection container
        /// </summary>
        /// <param name="services">Current service collection</param>
        /// <param name="configuration">Current service configuration</param>
        /// <returns>Current service collection with new Infrastructure services</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQConfiguration = configuration.GetSection("RabbitMQ");

            services.AddOptions<RabbitMQOptions>()
                    .Bind(rabbitMQConfiguration);

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();

            services.AddTransient<IMessageBrokerOrderCancelledConsumer, RabbitMQOrderCancelledConsumer>();
            services.AddHostedService<MessageBrokerOrderCancelledHostedService>();

            services.AddTransient<IMessageBrokerOrderStatusChangedConsumer, RabbitMQOrderStatusChangedConsumer>();
            services.AddHostedService<MessageBrokerOrderStatusChangedHostedService>();

            services.AddTransient<IMessageBrokerOrderCreatedConsumer, RabbitMQOrderCreatedConsumer>();
            services.AddHostedService<MessageBrokerOrderCreatedHostedService>();

            services.AddTransient<IMessageBrokerUpdateOrdersItemConsumer, RabbitMQUpdateOrderItemsConsumer>();
            services.AddHostedService<MessageBrokerOrderUpdatedHostedService>();

            return services;
        }
    }
}
