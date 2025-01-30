using InventoryService.Application.Interfaces;
using InventoryService.Application.Products.DTO;
using System.Collections.Generic;

namespace InventoryService.Application.Products.Queries.GetAllProducts
{
    /// <summary>
    /// Represents a query to retrieve all products.
    /// </summary>
    public record GetAllProductsQuery : IQueryRequest<IEnumerable<ProductDTO>>;
}
