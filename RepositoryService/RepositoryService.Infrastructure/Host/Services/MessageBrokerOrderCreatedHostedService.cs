using Microsoft.Extensions.Hosting;
using RepositoryService.Application.Interfaces.MessageBrokerConsumers;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Infrastructure.Host.Services
{
    internal class MessageBrokerOrderCreatedHostedService : IHostedService
    {
        private readonly IMessageBrokerOrderCreatedConsumer _orderCreatedConsumer;

        public MessageBrokerOrderCreatedHostedService(IMessageBrokerOrderCreatedConsumer orderCreatedConsumer)
        {
            _orderCreatedConsumer = orderCreatedConsumer;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _orderCreatedConsumer.ConsumeAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _orderCreatedConsumer.Dispose();
            return Task.CompletedTask;
        }
    }
}
