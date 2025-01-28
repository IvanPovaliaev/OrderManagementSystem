using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepositoryService.Application.Interfaces.MessageBrokerConsumers;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Infrastructure.Host.Services
{
    internal class MessageBrokerOrderCancelledHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public MessageBrokerOrderCancelledHostedService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var orderCanceledConsumer = scope.ServiceProvider.GetRequiredService<IMessageBrokerOrderCancelledConsumer>();
                await orderCanceledConsumer.ConsumeAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
