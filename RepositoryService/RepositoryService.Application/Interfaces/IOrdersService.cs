using RepositoryService.Application.Models.Messages;
using System.Threading.Tasks;

namespace RepositoryService.Application.Interfaces
{
    /// <summary>
    /// Defines a service contract for managing orders and retrieving order data.
    /// </summary>
    public interface IOrdersService
    {
        Task UpdateAsync(UpdateOrderItemsMessage order);
    }
}
