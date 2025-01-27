namespace OrderManagementService.Infrastructure.RepositoryService
{
    internal class RepositoryServiceOptions
    {
        public required string Url { get; init; }
        public required int Timeout { get; init; } = 5000;
    }
}
