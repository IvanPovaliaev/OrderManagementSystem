using System.Collections.Generic;

namespace OrderManagementService.Application.Models.DTOs
{
    public record NewOrderDTO
    {
        public string ClientFullName { get; init; }
        public string ClientPhone { get; init; }
        public List<OrderItemDTO> Items { get; init; }
    }
}
