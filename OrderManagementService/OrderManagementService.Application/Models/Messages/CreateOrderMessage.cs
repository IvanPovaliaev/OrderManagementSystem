using System.Collections.Generic;

namespace OrderManagementService.Application.Models.Messages
{
    internal record class CreateOrderMessage
    {
        public string ClientFullName { get; init; }
        public string ClientPhone { get; init; }
        public List<OrderItemDTO> Items { get; init; }
    }
}
