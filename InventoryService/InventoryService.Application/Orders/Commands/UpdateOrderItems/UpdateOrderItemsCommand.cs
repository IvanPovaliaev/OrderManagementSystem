using InventoryService.Application.Interfaces;
using InventoryService.Application.Models.Messages;

namespace InventoryService.Application.Orders.Commands.UpdateOrderItems
{
    /// <summary>
    /// Represents a command to cancel an order.
    /// </summary>
    /// <param name="Message">The message containing order details for update items.</param>
    public record UpdateOrderItemsCommand(UpdateOrderItemsMessage Message) : ICommandRequest;
}
