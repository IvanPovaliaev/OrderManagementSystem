using Microsoft.Extensions.Hosting;
using RepositoryService.Application.Interfaces.MessageBrokerConsumers;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Infrastructure.Host.Services
{
    internal class MessageBrokerOrderCanceledHostedService : IHostedService
    {
        private readonly IMessageBrokerOrderCanceledConsumer _orderCanceledConsumer;

        public MessageBrokerOrderCanceledHostedService(IMessageBrokerOrderCanceledConsumer orderCanceledConsumer)
        {
            _orderCanceledConsumer = orderCanceledConsumer;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _orderCanceledConsumer.ConsumeAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _orderCanceledConsumer.Dispose();
            return Task.CompletedTask;
        }
    }
}
