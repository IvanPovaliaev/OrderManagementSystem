namespace InventoryService.Infrastructure.RabbitMQ
{
    public class RabbitMQOptions
    {
        public string HostName { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }
        public int Port { get; init; }
        public string ExchangeName { get; init; }
        public string CancelOrderRoutingKey { get; init; }
        public string CancelOrderQueue { get; init; }
        public string CreateOrderRoutingKey { get; init; }
        public string CreateOrderQueue { get; init; }
        public string UpdateOrderItemsRoutingKey { get; init; }
        public string UpdateOrderItemsQueue { get; init; }
        public string ChangeStatusOrderRoutingKey { get; init; }
        public string ChangeStatusOrderQueue { get; init; }
    }
}
