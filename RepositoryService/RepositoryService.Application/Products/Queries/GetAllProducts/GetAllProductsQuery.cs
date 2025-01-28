using MediatR;
using RepositoryService.Application.Products.DTO;
using System.Collections.Generic;

namespace RepositoryService.Application.Products.Queries.GetAllProducts
{
    public record class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
