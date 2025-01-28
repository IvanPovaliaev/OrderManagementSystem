using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RepositoryService.Application.Interfaces;
using RepositoryService.Application.Interfaces.MessageBrokerConsumers;
using RepositoryService.Infrastructure.RabbitMQ.Messages;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Infrastructure.RabbitMQ.Consumers
{
    internal class RabbitMQOrderUpdatedConsumer : IMessageBrokerOrderUpdatedConsumer, IDisposable
    {
        private readonly IOptionsMonitor<RabbitMQOptions> _rabbitMQOptionsMonitor;
        private readonly IConnection _connection;
        private readonly IChannel _channel;
        private readonly IServiceProvider _serviceProvider;

        public RabbitMQOrderUpdatedConsumer(IOptionsMonitor<RabbitMQOptions> rabbitMQOptionsMonitor, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _rabbitMQOptionsMonitor = rabbitMQOptionsMonitor;
            var options = _rabbitMQOptionsMonitor.CurrentValue;
            var factory = new ConnectionFactory()
            {
                HostName = options.HostName,
                UserName = options.UserName,
                Password = options.Password,
                Port = options.Port
            };

            _connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
            _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();
        }

        public async Task ConsumeAsync()
        {
            var routingKey = "order.update";
            var queueName = "repository.orders.update.queue";
            var exchangeName = await DeclareExchangeAsync();

            await _channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            await _channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: routingKey);

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                if (message is not null)
                {
                    var orderMessage = JsonConvert.DeserializeObject<OrderStatusChangedMessage>(message);
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var orderService = scope.ServiceProvider.GetRequiredService<IOrdersService>();
                        await orderService.UpdateAsync(orderMessage!.Id, orderMessage.NewStatus);
                    }
                }

                return Task.CompletedTask;
            };

            await _channel.BasicConsumeAsync(queue: queueName, autoAck: true, consumer: consumer);
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        /// <summary>
        /// Declares an exchange
        /// </summary>
        /// <returns>The name of the declared exchange.</returns>
        private async Task<string> DeclareExchangeAsync()
        {
            var name = _rabbitMQOptionsMonitor.CurrentValue.ExchangeName;
            await _channel.ExchangeDeclareAsync(exchange: name, type: ExchangeType.Direct, durable: true);
            return name;
        }
    }
}
