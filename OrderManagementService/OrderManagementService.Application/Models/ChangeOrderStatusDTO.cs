using System;

namespace OrderManagementService.Application.Models
{
    public class ChangeOrderStatusDTO
    {
        public Guid Id { get; init; }
        public OrderStatus NewStatus { get; init; }
    }
}
