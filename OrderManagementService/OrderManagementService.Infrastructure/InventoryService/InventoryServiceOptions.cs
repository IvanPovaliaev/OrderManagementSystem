namespace OrderManagementService.Infrastructure.InventoryService
{
    public class InventoryServiceOptions
    {
        public required string Url { get; init; }
        public required int Timeout { get; init; } = 5000;
    }
}
