﻿using RepositoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryService.Domain.Interfaces
{
    /// <summary>
    /// Defines a contract for a repository that manages product entities.
    /// </summary>
    public interface IProductsRepository
    {
        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A collection of all products;</returns>
        Task<ICollection<Product>> GetAllAsync();

        /// <summary>
        /// Gets a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product with the specified ID; null if not found.</returns>
        Task<Product?> GetAsync(Guid id);
    }
}
