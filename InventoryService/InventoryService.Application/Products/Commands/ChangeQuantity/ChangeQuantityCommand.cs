using InventoryService.Application.Interfaces;
using System;

namespace InventoryService.Application.Products.Commands.ChangeQuantity
{
    /// <summary>
    /// Represents a command to change the quantity of a product.
    /// </summary>
    public record ChangeQuantityCommand(Guid Id, int QuantityChange) : ICommandRequest;
}
