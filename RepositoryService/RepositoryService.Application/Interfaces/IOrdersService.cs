using RepositoryService.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryService.Application.Interfaces
{
    /// <summary>
    /// Defines a service for managing orders and retrieving order data.
    /// </summary>
    public interface IOrdersService
    {
        /// <summary>
        /// Retrieves all orders from the repository.
        /// </summary>
        /// <returns>A collection of <see cref="OrderDTO"/> instances</returns>
        Task<ICollection<OrderDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves a order from the repository by its unique identifier
        /// </summary>
        /// <returns>
        /// A <see cref="OrderDTO"/> representing the order with the specified ID; null if not found.
        /// </returns>
        Task<OrderDTO?> GetAsync(Guid id);
    }
}
