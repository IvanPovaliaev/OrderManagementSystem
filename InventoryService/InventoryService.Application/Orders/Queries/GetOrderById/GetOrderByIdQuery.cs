using InventoryService.Application.Interfaces;
using InventoryService.Application.Models;
using System;

namespace InventoryService.Application.Orders.Queries.GetOrderById
{
    /// <summary>
    /// Represents a query to retrieve an order by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the order.</param>
    public record class GetOrderByIdQuery(Guid Id) : IQueryRequest<OrderDetailsDTO?>;
}
