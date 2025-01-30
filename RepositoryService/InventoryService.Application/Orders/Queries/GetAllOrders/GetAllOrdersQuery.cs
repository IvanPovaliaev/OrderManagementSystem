using InventoryService.Application.Interfaces;
using InventoryService.Application.Models;
using System.Collections.Generic;

namespace InventoryService.Application.Orders.Queries.GetAllOrders
{
    /// <summary>
    /// Represents a query to retrieve all orders.
    /// </summary>
    public record class GetAllOrdersQuery : IQueryRequest<IEnumerable<OrderDTO>>;
}
