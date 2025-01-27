namespace OrderManagementService.Infrastructure.RabbitMQ
{
    internal class RabbitMQOptions
    {
        public string HostName { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }
        public int Port { get; init; }
        public string ExchangeName { get; init; }
    }
}
