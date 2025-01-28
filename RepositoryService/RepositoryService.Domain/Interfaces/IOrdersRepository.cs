using RepositoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryService.Domain.Interfaces
{
    /// <summary>
    /// Defines a contract for a repository that manages order entities.
    /// </summary>
    public interface IOrdersRepository
    {
        Task AddAsync(Order order);

        /// <summary>
        /// Retrieves all orders.
        /// </summary>
        /// <returns>A collection of all orders;</returns>
        Task<ICollection<Order>> GetAllAsync();

        /// <summary>
        /// Gets a order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The order with the specified ID; null if not found.</returns>
        Task<Order?> GetAsync(Guid id);

        Task UpdateAsync(Order order);
    }
}
