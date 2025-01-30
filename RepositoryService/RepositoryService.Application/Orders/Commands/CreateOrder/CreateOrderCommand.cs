using RepositoryService.Application.Interfaces;
using RepositoryService.Application.Models.Messages;

namespace RepositoryService.Application.Orders.Commands.CreateOrder
{
    /// <summary>
    /// Represents a command to create a new order.
    /// </summary>
    /// <param name="Message">The message containing order details.</param>
    public record CreateOrderCommand(CreateOrderMessage Message) : ICommandRequest;
}
