﻿using System;

namespace InventoryService.Application.Models
{
    public record OrderItemDTO
    {
        public Guid Id { get; init; }
        public Guid OrderId { get; init; }
        public Guid ProductId { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
