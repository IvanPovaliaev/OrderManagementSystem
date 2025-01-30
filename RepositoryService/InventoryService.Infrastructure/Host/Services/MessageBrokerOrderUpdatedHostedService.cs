using InventoryService.Application.Interfaces.MessageBrokerConsumers;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Host.Services
{
    internal class MessageBrokerOrderUpdatedHostedService : IHostedService
    {
        private readonly IMessageBrokerUpdateOrdersItemConsumer _orderUpdatedConsumer;

        public MessageBrokerOrderUpdatedHostedService(IMessageBrokerUpdateOrdersItemConsumer orderOrderUpdatedConsumer)
        {
            _orderUpdatedConsumer = orderOrderUpdatedConsumer;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _orderUpdatedConsumer.ConsumeAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _orderUpdatedConsumer.Dispose();
            return Task.CompletedTask;
        }
    }
}
