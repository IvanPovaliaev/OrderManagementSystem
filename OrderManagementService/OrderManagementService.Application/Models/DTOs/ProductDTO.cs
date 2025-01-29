using System;

namespace OrderManagementService.Application.Models.DTOs
{
    public record ProductDTO
    {
        public Guid Id { get; init; }
        public string Article { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public float Price { get; init; }
        public int QuantityInStock { get; init; }
    }
}
