using RepositoryService.Application.Interfaces;
using RepositoryService.Application.Models;
using System;

namespace RepositoryService.Application.Orders.Queries.GetOrderById
{
    /// <summary>
    /// Represents a query to retrieve an order by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the order.</param>
    public record class GetOrderByIdQuery(Guid Id) : IQueryRequest<OrderDetailsDTO?>;
}
