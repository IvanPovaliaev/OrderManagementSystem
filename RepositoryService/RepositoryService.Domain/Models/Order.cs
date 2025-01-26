using System;
using System.Collections.Generic;

namespace RepositoryService.Domain.Models
{
    public class Order
    {
        public Guid Id { get; init; }
        public DateTime CreationDate { get; init; }
        public DateTime StoreUntil { get; set; }
        public OrderStatus Status { get; set; }
        public string ClientFullName { get; set; }
        public string ClientPhone { get; set; }
        public List<OrderItem> Items { get; set; }
        public int TotalItems => Items.Count;
        public decimal Cost { get; set; }
    }
}
