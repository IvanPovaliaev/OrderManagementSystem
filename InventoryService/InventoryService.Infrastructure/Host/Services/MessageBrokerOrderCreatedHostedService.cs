using InventoryService.Application.Interfaces.MessageBrokerConsumers;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Host.Services
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
