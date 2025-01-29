using System;
using System.Collections.Generic;

namespace OrderManagementService.Application.Models.DTOs
{
    public record UpdateOrderItemsDTO
    {
        public Guid Id { get; init; }
        public List<OrderItemDTO> Items { get; init; }
    }
}
