using System;
using System.Collections.Generic;

namespace OrderManagementService.Application.Models.DTOs
{
    public record OrderDTO
    {
        public Guid Id { get; init; }
        public DateTime CreationDate { get; init; }
        public DateTime StoreUntil { get; init; }
        public OrderStatus Status { get; init; }
        public string ClientFullName { get; init; }
        public string ClientPhone { get; init; }
        public List<OrderItemDTO> Items { get; init; }
        public int TotalItems { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
