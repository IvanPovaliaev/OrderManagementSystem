using System.Collections.Generic;

namespace OrderManagementService.Application.Models
{
    public record class NewOrderDTO
    {
        public string ClientFullName { get; init; }
        public string ClientPhone { get; init; }
        public List<OrderItemDTO> Items { get; init; }
    }
}
