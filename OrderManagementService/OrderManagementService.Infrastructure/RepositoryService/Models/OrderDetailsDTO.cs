using System.Collections.Generic;

namespace OrderManagementService.Infrastructure.RepositoryService.Models
{
    public record class OrderDetailsDTO : OrderDTO
    {
        public List<OrderItemDTO> Items { get; init; }
    }
}
