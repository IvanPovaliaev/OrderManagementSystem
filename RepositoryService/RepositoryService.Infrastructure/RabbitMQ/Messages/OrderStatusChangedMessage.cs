using RepositoryService.Domain.Models;
using System;

namespace RepositoryService.Infrastructure.RabbitMQ.Messages
{
    internal record class OrderStatusChangedMessage(Guid Id, OrderStatus NewStatus);
}
