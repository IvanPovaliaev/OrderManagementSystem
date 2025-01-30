using InventoryService.Application.Interfaces;
using System;

namespace InventoryService.Application.Orders.Commands.CancelOrder
{
    /// <summary>
    /// Represents a command to cancel an order.
    /// </summary>
    /// <param name="Id">The unique identifier of the order to be canceled.</param>
    public record CancelOrderCommand(Guid Id) : ICommandRequest;
}
