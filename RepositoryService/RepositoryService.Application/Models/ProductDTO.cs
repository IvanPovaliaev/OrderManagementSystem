using System;

namespace RepositoryService.Application.Models
{
    public record class ProductDTO
    {
        public Guid Id { get; init; }
        public string Article { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public int QuantityInStock { get; init; }
    }
}
