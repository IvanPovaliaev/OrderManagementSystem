using MediatR;
using RepositoryService.Application.Products.DTO;
using System.Collections.Generic;

namespace RepositoryService.Application.Products.Queries.GetAllProducts
{
    /// <summary>
    /// Represents a query to retrieve all products.
    /// </summary>
    public record class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
