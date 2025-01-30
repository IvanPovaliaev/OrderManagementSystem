using System.Collections.Generic;

namespace InventoryService.Application.Models
{
    public record class OrderDetailsDTO : OrderDTO
    {
        public List<OrderItemDTO> Items { get; init; }
    }
}
