using System;

namespace OrderManagementService.Application.Models.Messages
{
    internal record class ChangeOrderStatusMessage(Guid Id, OrderStatus NewStatus);
}
