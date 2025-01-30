using System.Threading.Tasks;

namespace InventoryService.Application.Interfaces.MessageBrokerConsumers
{
    /// <summary>
    /// Defines a contract for a consumer that processes messages related to created orders from a message broker.
    /// </summary>
    public interface IMessageBrokerOrderCreatedConsumer
    {
        /// <summary>
        /// Starts consuming messages related to created orders.
        /// </summary>
        Task ConsumeAsync();

        /// <summary>
        /// Releases resources associated with the consumer.
        /// </summary>
        void Dispose();
    }
}