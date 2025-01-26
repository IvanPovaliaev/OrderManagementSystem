using System.Collections.Generic;

namespace RepositoryService.Application.Models
{
    public record class OrderDetailsDTO : OrderDTO
    {
        public List<OrderItemDTO> Items { get; init; }
    }
}
