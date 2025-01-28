using MediatR;
using RepositoryService.Application.Models;
using System.Collections.Generic;

namespace RepositoryService.Application.Orders.Queries.GetAllOrders
{
    public record class GetAllOrdersQuery : IRequest<IEnumerable<OrderDTO>>
    {
    }
}
