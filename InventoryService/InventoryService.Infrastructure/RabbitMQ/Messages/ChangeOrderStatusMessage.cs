using InventoryService.Domain.Models;
using System;

namespace InventoryService.Infrastructure.RabbitMQ.Messages
{
    internal record ChangeOrderStatusMessage(Guid Id, OrderStatus NewStatus);
}
