using OrderManagementService.Application.Models;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.Application.Interfaces
{
    public interface IOrdersService
    {
        Task<bool> CancelAsync(Guid id);
        Task<bool> ChangeStatusAsync(ChangeOrderStatusDTO order);
        Task<bool> IsExistAsync(Guid id);
    }
}
