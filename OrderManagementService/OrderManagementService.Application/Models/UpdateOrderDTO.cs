using System;
using System.Collections.Generic;

namespace OrderManagementService.Application.Models
{
    public record class UpdateOrderDTO
    {
        public Guid Id { get; init; }
        public List<OrderItemDTO> Items { get; init; }
    }
}
