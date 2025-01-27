using OrderManagementService.Infrastructure.RepositoryService.Models;
using System.Collections.Generic;

namespace OrderManagementService.Application.Models
{
    public class CreateOrderDTO
    {
        public string ClientFullName { get; init; }
        public string ClientPhone { get; init; }
        public List<OrderItemDTO> Items { get; init; }
    }
}
