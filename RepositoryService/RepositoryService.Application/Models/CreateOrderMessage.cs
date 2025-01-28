using System.Collections.Generic;

namespace RepositoryService.Application.Models
{
    public record class CreateOrderMessage
    {
        public string ClientFullName { get; init; }
        public string ClientPhone { get; init; }
        public List<OrderItemRequest> Items { get; init; }
    }
}
