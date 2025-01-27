using Microsoft.Extensions.Hosting;
using RepositoryService.Application.Interfaces.MessageBrokerConsumers;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Infrastructure.Host.Services
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
