using MediatR;
using System;

namespace RepositoryService.Application.Products.Commands.ChangeQuantity
{
    /// <summary>
    /// Represents a command to change the quantity of a product.
    /// </summary>
    public record class ChangeQuantityCommand : IRequest
    {
        public Guid Id { get; init; }
        public int QuantityChange { get; init; }
    }
}
