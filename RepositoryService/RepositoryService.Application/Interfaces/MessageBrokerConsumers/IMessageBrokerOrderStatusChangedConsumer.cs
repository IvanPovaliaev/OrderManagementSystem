using System.Threading.Tasks;

namespace RepositoryService.Application.Interfaces.MessageBrokerConsumers
{
    public interface IMessageBrokerOrderStatusChangedConsumer
    {
        Task ConsumeAsync();
        void Dispose();
    }
}