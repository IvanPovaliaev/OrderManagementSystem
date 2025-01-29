using MediatR;
using RepositoryService.Application.Models.Messages;

namespace RepositoryService.Application.Orders.Commands.UpdateOrderItems
{
    /// <summary>
    /// Represents a command to cancel an order.
    /// </summary>
    /// <param name="Message">The message containing order details for update items.</param>
    public record UpdateOrderItemsCommand(UpdateOrderItemsMessage Message) : IRequest;
}
