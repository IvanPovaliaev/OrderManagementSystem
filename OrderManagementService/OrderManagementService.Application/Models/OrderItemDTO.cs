using System;

namespace OrderManagementService.Application.Models
{
    public class OrderItemDTO
    {
        public Guid ProductId { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
    }
}
