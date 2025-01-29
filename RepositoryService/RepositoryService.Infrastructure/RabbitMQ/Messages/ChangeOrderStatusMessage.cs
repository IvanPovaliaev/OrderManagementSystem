using RepositoryService.Domain.Models;
using System;

namespace RepositoryService.Infrastructure.RabbitMQ.Messages
{
    internal record ChangeOrderStatusMessage(Guid Id, OrderStatus NewStatus);
}
