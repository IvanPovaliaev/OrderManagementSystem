using RepositoryService.Application.Models.Messages;
using RepositoryService.Domain.Models;
using System;
using System.Threading.Tasks;

namespace RepositoryService.Application.Interfaces
{
    /// <summary>
    /// Defines a service contract for managing orders and retrieving order data.
    /// </summary>
    public interface IOrdersService
    {
        Task CreateAsync(CreateOrderMessage newOrder);

        Task UpdateAsync(UpdateOrderMessage order);

        Task ChangeStatusAsync(Guid id, OrderStatus newStatus);
    }
}
