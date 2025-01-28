using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OrderManagementService.Application.Interfaces;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Infrastructure.RabbitMQ
{
    /// <summary>
    /// Provides functionality for publishing messages to RabbitMQ.
    /// </summary>
    /// <remarks>
    /// This class implements the <see cref="IMessageBrokerPublisher"/> interface and is responsible for sending messages to RabbitMQ.
    /// It also implements <see cref="IDisposable"/> to properly release RabbitMQ connection and channel resources.
    /// </remarks>
    internal class RabbitMQPublisher : IMessageBrokerPublisher, IDisposable
    {
        private readonly IOptionsMonitor<RabbitMQOptions> _rabbitMQOptionsMonitor;
        private readonly IConnection _connection;
        private readonly IChannel _channel;

        public RabbitMQPublisher(IOptionsMonitor<RabbitMQOptions> rabbitMQOptionsMonitor)
        {
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

        public async Task PublishAsync<T>(string routingKey, T message)
        {
            var messageJson = JsonConvert.SerializeObject(message, Formatting.Indented);
            var messageBody = Encoding.UTF8.GetBytes(messageJson);

            var exchangeName = await DeclareExchangeAsync();

            await _channel.BasicPublishAsync(exchange: exchangeName, routingKey: routingKey, messageBody);
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }


        /// <summary>
        /// Declares an exchange in RabbitMQ.
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
