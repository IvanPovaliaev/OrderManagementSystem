using OrderManagementService.Application.Models;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.Application.Interfaces
{
    /// <summary>
    /// Defines a service contract for managing orders.
    /// </summary>
    public interface IOrdersService
    {
        Task<bool> CreateAsync(NewOrderDTO newOrder);

        /// <summary>
        /// Cancels an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to cancel.</param>
        /// <returns>The task result is <c>true</c> if the order was successfully canceled; otherwise, <c>false</c>.</returns>
        Task<bool> CancelAsync(Guid id);

        /// <summary>
        /// Changes the status of an order based on the provided data.
        /// </summary>
        /// <param name="order">The data transfer object containing the order identifier and the new status.</param>
        /// <returns>The task result is <c>true</c> if the status was successfully changed; otherwise, <c>false</c>.</returns>
        Task<bool> ChangeStatusAsync(ChangeOrderStatusDTO order);

        /// <summary>
        /// Сhecks whether an order with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the order to check.</param>
        /// <returns>The task result is <c>true</c> if the order exists; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">
        Task<bool> IsExistAsync(Guid id);
    }
}
