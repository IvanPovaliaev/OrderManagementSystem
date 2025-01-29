using MediatR;
using RepositoryService.Application.Models;
using System.Collections.Generic;

namespace RepositoryService.Application.Orders.Queries.GetAllOrders
{
    /// <summary>
    /// Represents a query to retrieve all orders.
    /// </summary>
    public record class GetAllOrdersQuery : IRequest<IEnumerable<OrderDTO>>
    {
    }
}
