using FluentValidation;
using InventoryService.Application.Extensions;
using InventoryService.Application.Interfaces.MessageBrokerConsumers;
using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure.Host.Services;
using InventoryService.Infrastructure.Persistence.Repositories;
using InventoryService.Infrastructure.Persistence.UnitOfWork;
using InventoryService.Infrastructure.RabbitMQ;
using InventoryService.Infrastructure.RabbitMQ.Consumers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryService.Infrastructure
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
            services.AddValidatorsFromAssemblyContaining<RabbitMQOptionsValidator>();

            var rabbitMQConfiguration = configuration.GetSection("RabbitMQ");

            services.AddOptions<RabbitMQOptions>()
                    .Bind(rabbitMQConfiguration)
                    .ValidateFluentValidation()
                    .ValidateOnStart();

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

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
