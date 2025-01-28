using System.Threading.Tasks;

namespace RepositoryService.Application.Interfaces.MessageBrokerConsumers
{
    /// <summary>
    /// Defines a contract for a consumer that processes messages related to order status changes from a message broker.
    /// </summary>
    public interface IMessageBrokerOrderStatusChangedConsumer
    {
        /// <summary>
        /// Starts consuming messages related to canceled orders.
        /// </summary>
        Task ConsumeAsync();

        /// <summary>
        /// Releases resources associated with the consumer.
        /// </summary>
        void Dispose();
    }
}