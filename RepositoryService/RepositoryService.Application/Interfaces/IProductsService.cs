using RepositoryService.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryService.Application.Interfaces
{
    /// <summary>
    /// Defines a service contract for managing products and retrieving product data.
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Retrieves all products from the repository.
        /// </summary>
        /// <returns>A collection of <see cref="ProductDTO"/> instances</returns>
        Task<ICollection<ProductDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves a product from the repository by its unique identifier
        /// </summary>
        /// <returns>
        /// A <see cref="ProductDTO"/> representing the product with the specified ID; null if not found.
        /// </returns>
        Task<ProductDTO?> GetAsync(Guid id);
    }
}
