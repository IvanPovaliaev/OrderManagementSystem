using RepositoryService.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryService.Application.Interfaces
{
    /// <summary>
    /// Defines a service contract for managing orders and retrieving order data.
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
        /// A <see cref="OrderDetailsDTO"/> representing the order with the specified ID with all details information; null if not found.
        /// </returns>
        Task<OrderDetailsDTO?> GetAsync(Guid id);

        Task CancelAsync(Guid id);
    }
}
