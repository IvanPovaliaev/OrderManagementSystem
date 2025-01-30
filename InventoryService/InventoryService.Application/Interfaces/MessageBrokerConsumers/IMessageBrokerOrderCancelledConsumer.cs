using System.Threading.Tasks;

namespace InventoryService.Application.Interfaces.MessageBrokerConsumers
{
    /// <summary>
    /// Defines a contract for a consumer that processes messages related to canceled orders from a message broker.
    /// </summary>
    public interface IMessageBrokerOrderCancelledConsumer
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