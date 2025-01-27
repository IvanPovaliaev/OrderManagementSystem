namespace OrderManagementService.Infrastructure.RepositoryService
{
    public class RepositoryServiceOptions
    {
        public required string Url { get; init; }
        public required int Timeout { get; init; } = 5000;
    }
}
