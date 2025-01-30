using RepositoryService.Application.Interfaces;
using System;

namespace RepositoryService.Application.Orders.Commands.CancelOrder
{
    /// <summary>
    /// Represents a command to cancel an order.
    /// </summary>
    /// <param name="Id">The unique identifier of the order to be canceled.</param>
    public record CancelOrderCommand(Guid Id) : ICommandRequest;
}
