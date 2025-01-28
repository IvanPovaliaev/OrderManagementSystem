using MediatR;
using RepositoryService.Application.Models.Messages;

namespace RepositoryService.Application.Orders.Commands.CreateOrder
{
    public record class CreateOrderCommand(CreateOrderMessage Message) : IRequest;
}
