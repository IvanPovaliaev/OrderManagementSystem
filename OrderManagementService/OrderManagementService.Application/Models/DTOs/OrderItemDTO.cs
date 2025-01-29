using System;

namespace OrderManagementService.Application.Models.DTOs
{
    public record OrderItemDTO
    {
        public Guid ProductId { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
    }
}
