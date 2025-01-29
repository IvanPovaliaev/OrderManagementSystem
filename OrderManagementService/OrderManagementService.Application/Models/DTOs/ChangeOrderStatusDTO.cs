using System;

namespace OrderManagementService.Application.Models.DTOs
{
    public record ChangeOrderStatusDTO
    {
        public Guid Id { get; init; }
        public OrderStatus NewStatus { get; init; }
    }
}
