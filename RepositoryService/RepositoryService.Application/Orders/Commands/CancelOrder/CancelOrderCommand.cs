using MediatR;
using System;

namespace RepositoryService.Application.Orders.Commands.CancelOrder
{
    /// <summary>
    /// Represents a command to cancel an order.
    /// </summary>
    /// <param name="Id">The unique identifier of the order to be canceled.</param>
    public record class CancelOrderCommand(Guid Id) : IRequest;
}
