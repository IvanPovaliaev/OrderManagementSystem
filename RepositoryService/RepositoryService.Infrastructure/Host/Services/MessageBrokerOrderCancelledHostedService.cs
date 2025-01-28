using Microsoft.Extensions.Hosting;
using RepositoryService.Application.Interfaces.MessageBrokerConsumers;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Infrastructure.Host.Services
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
