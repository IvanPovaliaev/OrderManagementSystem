using InventoryService.Application.Interfaces.MessageBrokerConsumers;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Host.Services
{
    internal class MessageBrokerOrderCancelledHostedService : IHostedService
    {
        private readonly IMessageBrokerOrderCancelledConsumer _orderCancelledConsumer;

        public MessageBrokerOrderCancelledHostedService(IMessageBrokerOrderCancelledConsumer orderCancelledConsumer)
        {
            _orderCancelledConsumer = orderCancelledConsumer;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _orderCancelledConsumer.ConsumeAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _orderCancelledConsumer.Dispose();
            return Task.CompletedTask;
        }
    }
}
