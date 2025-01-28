using RepositoryService.Domain.Models;
using System;
using System.Collections.Generic;

namespace RepositoryService.Application.Models.Messages
{
    public record class CreateOrderMessage
    {
        public DateTime CreationDate { get; init; }
        public DateTime StoreUntil { get; init; }
        public OrderStatus Status { get; init; }
        public string ClientFullName { get; init; }
        public string ClientPhone { get; init; }
        public List<OrderItemRequest> Items { get; init; }
        public int TotalItems { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
