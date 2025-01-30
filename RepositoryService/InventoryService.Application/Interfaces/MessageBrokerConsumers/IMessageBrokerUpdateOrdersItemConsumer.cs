using System.Threading.Tasks;

namespace InventoryService.Application.Interfaces.MessageBrokerConsumers
{
    /// <summary>
    /// Defines a contract for a consumer that processes messages related to updated orders from a message broker.
    /// </summary>
    public interface IMessageBrokerUpdateOrdersItemConsumer
    {
        /// <summary>
        /// Starts consuming messages related to updated orders.
        /// </summary>
        Task ConsumeAsync();

        /// <summary>
        /// Releases resources associated with the consumer.
        /// </summary>
        void Dispose();
    }
}