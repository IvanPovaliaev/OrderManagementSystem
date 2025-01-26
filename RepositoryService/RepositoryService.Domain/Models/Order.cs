using System;
using System.Collections.Generic;

namespace RepositoryService.Domain.Models
{
    public class Order
    {
        public Guid Id { get; init; }
        public DateTime CreationDate { get; init; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; }
        public string ClientFullName { get; set; }
        public string ClientPhone { get; set; }
        public List<OrderItem> Items { get; set; }
        public int TotalItems => Items.Count;
        public decimal Cost { get; set; }
    }
}
