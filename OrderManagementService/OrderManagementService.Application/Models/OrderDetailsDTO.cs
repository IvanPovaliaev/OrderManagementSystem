using System.Collections.Generic;

namespace OrderManagementService.Application.Models
{
    public record class OrderDetailsDTO : OrderDTO
    {
        public List<OrderItemDTO> Items { get; init; }
    }
}
