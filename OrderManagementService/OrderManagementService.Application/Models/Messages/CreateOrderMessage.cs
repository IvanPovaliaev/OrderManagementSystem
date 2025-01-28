using System;
using System.Collections.Generic;

namespace OrderManagementService.Application.Models.Messages
{
    internal record class CreateOrderMessage
    {
        public DateTime CreationDate { get; init; } = DateTime.UtcNow;
        public DateTime StoreUntil { get; init; }
        public OrderStatus Status { get; init; } = OrderStatus.Created;
        public string ClientFullName { get; init; }
        public string ClientPhone { get; init; }
        public List<OrderItemDTO> Items { get; init; }
        public int TotalItems { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
