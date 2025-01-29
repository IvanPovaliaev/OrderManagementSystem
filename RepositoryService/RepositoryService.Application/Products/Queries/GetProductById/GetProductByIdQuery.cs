using MediatR;
using RepositoryService.Application.Products.DTO;
using System;

namespace RepositoryService.Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Represents a query to retrieve a product by its unique identifier.
    /// </summary>
    public record class GetProductByIdQuery : IRequest<ProductDTO?>
    {
        public Guid Id { get; init; }
    }
}
