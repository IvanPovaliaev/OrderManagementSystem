using System;

namespace OrderManagementService.Application.Models.Messages
{
    internal record class OrderStatusChangedMessage(Guid Id, OrderStatus NewStatus);
}
