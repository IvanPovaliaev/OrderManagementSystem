using MediatR;
using System;

namespace RepositoryService.Application.Products.Commands.ChangeQuantity
{
    public record class ChangeQuantityCommand : IRequest
    {
        public Guid Id { get; init; }
        public int QuantityChange { get; init; }
    }
}
