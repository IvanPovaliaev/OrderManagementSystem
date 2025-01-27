using System.Threading.Tasks;

namespace OrderManagementService.Application.Interfaces
{
    public interface IMessageBrokerPublisher
    {
        Task PublishAsync<T>(string routingKey, T message);
    }
}
