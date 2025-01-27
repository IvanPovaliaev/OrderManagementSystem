using System;

namespace OrderManagementService.Infrastructure.RepositoryService.Models
{
    public class OrderItemDTO
    {
        public Guid Id { get; init; }
        public Guid OrderId { get; init; }
        public ProductDTO Product { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
