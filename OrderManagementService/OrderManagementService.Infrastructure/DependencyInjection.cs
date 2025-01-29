using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementService.Application.Extensions;
using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Models.Options;
using OrderManagementService.Infrastructure.RabbitMQ;
using OrderManagementService.Infrastructure.RepositoryService;
using System;
using System.Net.Http.Headers;

namespace OrderManagementService.Infrastructure
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

            var repositoryServiceConfiguration = configuration.GetSection("Microservices:RepositoryService");

            services.AddOptions<RepositoryServiceOptions>()
                    .Bind(repositoryServiceConfiguration)
                    .ValidateFluentValidation()
                    .ValidateOnStart();

            services.AddHttpClient<IRepositoryServiceClient, RepositoryServiceClient>(client =>
            {
                var options = repositoryServiceConfiguration.Get<RepositoryServiceOptions>();
                client.BaseAddress = new Uri(options!.Url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromMilliseconds(options.Timeout);
            });

            var rabbitMQConfiguration = configuration.GetSection("RabbitMQ");

            services.AddOptions<RabbitMQOptions>()
                    .Bind(rabbitMQConfiguration)
                    .ValidateFluentValidation()
                    .ValidateOnStart();

            services.AddTransient<IMessageBrokerPublisher, RabbitMQPublisher>();

            return services;
        }
    }
}
