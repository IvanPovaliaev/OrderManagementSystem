using InventoryService.Application.Interfaces;
using InventoryService.Application.Products.DTO;
using System;

namespace InventoryService.Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Represents a query to retrieve a product by its unique identifier.
    /// </summary>
    public record GetProductByIdQuery : IQueryRequest<ProductDTO?>
    {
        public Guid Id { get; init; }
    }
}
