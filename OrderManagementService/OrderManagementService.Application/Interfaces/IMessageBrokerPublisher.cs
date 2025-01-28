using System.Threading.Tasks;

namespace OrderManagementService.Application.Interfaces
{
    /// <summary>
    /// Defines a contract for publishing messages to a message broker.
    /// </summary>
    public interface IMessageBrokerPublisher
    {
        /// <summary>
        /// Publishes a message to the message broker with the specified routing key.
        /// </summary>
        /// <typeparam name="T">The type of the message to be published.</typeparam>
        /// <param name="routingKey">The routing key used to route the message to the appropriate destination.</param>
        /// <param name="message">The message to be published.</param>
        Task PublishAsync<T>(string routingKey, T message);
    }
}
