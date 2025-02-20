﻿using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Models
{
    public class Order
    {
        public Guid Id { get; init; }
        public DateTime CreationDate { get; init; } = DateTime.UtcNow;
        public DateTime StoreUntil { get; set; }
        public OrderStatus Status { get; set; }
        public string ClientFullName { get; set; }
        public string ClientPhone { get; set; }
        public List<OrderItem> Items { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
