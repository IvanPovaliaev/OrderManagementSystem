using MediatR;
using RepositoryService.Domain.Models;
using System;

namespace RepositoryService.Application.Orders.Commands.ChangeOrderStatus
{
    public record class ChangeOrderStatusCommand(Guid Id, OrderStatus NewStatus) : IRequest;
}
