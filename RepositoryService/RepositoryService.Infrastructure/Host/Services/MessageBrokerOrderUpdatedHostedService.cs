using Microsoft.Extensions.Hosting;
using RepositoryService.Application.Interfaces.MessageBrokerConsumers;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Infrastructure.Host.Services
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
