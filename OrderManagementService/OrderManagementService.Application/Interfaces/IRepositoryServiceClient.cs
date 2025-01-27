using OrderManagementService.Infrastructure.RepositoryService.Models;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.Application.Interfaces
{
    public interface IRepositoryServiceClient
    {
        Task<ProductDTO?> GetProductByIdAsync(Guid id);
        Task<OrderDTO?> GetOrderByIdAsync(Guid id);
    }
}
