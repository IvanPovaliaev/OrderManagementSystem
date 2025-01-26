using System;

namespace RepositoryService.Domain.Models
{
    public class OrderItem
    {
        public Guid Id { get; init; }
        public Guid OrderId { get; init; }
        public Guid ProductId { get; init; }
        public Product Product { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; set; }
    }
}
