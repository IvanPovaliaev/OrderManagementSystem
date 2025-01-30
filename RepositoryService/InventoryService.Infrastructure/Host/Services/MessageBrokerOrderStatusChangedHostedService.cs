using InventoryService.Application.Interfaces.MessageBrokerConsumers;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Host.Services
{
    internal class MessageBrokerOrderStatusChangedHostedService : IHostedService
    {
        private readonly IMessageBrokerOrderStatusChangedConsumer _orderStatusChanged;

        public MessageBrokerOrderStatusChangedHostedService(IMessageBrokerOrderStatusChangedConsumer orderStatusChangedConsumer)
        {
            _orderStatusChanged = orderStatusChangedConsumer;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _orderStatusChanged.ConsumeAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _orderStatusChanged.Dispose();
            return Task.CompletedTask;
        }
    }
}
