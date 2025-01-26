using RepositoryService.Domain.Models;
using System;

namespace RepositoryService.Application.Models
{
    public record class OrderDTO
    {
        public Guid Id { get; init; }
        public DateTime CreationDate { get; init; }
        public DateTime StoreUntil { get; init; }
        public OrderStatus Status { get; init; }
        public string ClientFullName { get; init; }
        public string ClientPhone { get; init; }
        public int TotalItems { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
