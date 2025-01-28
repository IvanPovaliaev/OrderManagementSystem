﻿using System;

namespace RepositoryService.Application.Models
{
    public class OrderItemRequest
    {
        public Guid Id { get; init; }
        public Guid OrderId { get; init; }
        public Guid ProductId { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
