using OrderManagementService.Application.Models;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for a client that interacts with the repository service to retrieve related data.
    /// </summary>
    public interface IRepositoryServiceClient
    {
        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The task result contains the <see cref="ProductDTO"/> if the request is successful; otherwise, <c>null</c>./returns>
        Task<ProductDTO?> GetProductByIdAsync(Guid id);

        /// <summary>
        /// Retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns> The task result contains the <see cref="OrderDTO"/> if the request is successful; otherwise, <c>null</c></returns>
        Task<OrderDTO?> GetOrderByIdAsync(Guid id);
    }
}
