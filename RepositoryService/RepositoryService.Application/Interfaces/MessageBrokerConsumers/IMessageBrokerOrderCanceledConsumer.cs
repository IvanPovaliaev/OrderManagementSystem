using System.Threading.Tasks;

namespace RepositoryService.Application.Interfaces.MessageBrokerConsumers
{
    public interface IMessageBrokerOrderCanceledConsumer
    {
        Task ConsumeAsync();
    }
}