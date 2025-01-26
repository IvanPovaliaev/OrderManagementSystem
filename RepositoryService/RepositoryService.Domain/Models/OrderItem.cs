using System;

namespace RepositoryService.Domain.Models
{
    public class OrderItem
    {
        public Guid Id { get; init; }
        public required Guid ProductId { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
