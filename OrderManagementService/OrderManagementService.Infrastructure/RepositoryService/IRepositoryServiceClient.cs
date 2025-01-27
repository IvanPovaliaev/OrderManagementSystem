using OrderManagementService.Infrastructure.RepositoryService.Models;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.Infrastructure.RepositoryService
{
    public interface IRepositoryServiceClient
    {
        Task<ProductDTO?> GetProductByIdAsync(Guid id);
        Task<OrderDTO?> GetOrderByIdAsync(Guid id);
    }
}
