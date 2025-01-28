using System.Collections.Generic;

namespace OrderManagementService.Application.Models.Messages
{
    internal record class UpdateOrderMessage
    {
        public List<OrderItemDTO> Items { get; init; }
        public int TotalItems { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
