using InventoryService.Application.Interfaces;
using InventoryService.Application.Models.Messages;

namespace InventoryService.Application.Orders.Commands.CreateOrder
{
    /// <summary>
    /// Represents a command to create a new order.
    /// </summary>
    /// <param name="Message">The message containing order details.</param>
    public record CreateOrderCommand(CreateOrderMessage Message) : ICommandRequest;
}
