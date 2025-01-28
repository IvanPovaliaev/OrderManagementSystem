using MediatR;
using RepositoryService.Application.Products.DTO;
using System;

namespace RepositoryService.Application.Products.Queries.GetProductById
{
    public record class GetProductByIdQuery : IRequest<ProductDTO?>
    {
        public Guid Id { get; init; }
    }
}
