using InventoryService.Application.Models;
using System;
using System.Collections.Generic;

namespace InventoryService.Application.Models.Messages
{
    public record UpdateOrderItemsMessage
    {
        public Guid Id { get; init; }
        public List<OrderItemDTO> AddedItems { get; init; }
        public List<OrderItemDTO> UpdatedItems { get; init; }
        public List<Guid> RemovedProductIds { get; init; }
        public int TotalItems { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
