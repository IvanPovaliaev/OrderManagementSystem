using MediatR;
using System;

namespace RepositoryService.Application.Orders.Commands.CancelOrder
{
    public record class CancelOrderCommand(Guid Id) : IRequest;
}
