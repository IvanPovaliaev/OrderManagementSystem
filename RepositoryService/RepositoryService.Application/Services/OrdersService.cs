using RepositoryService.Application.Interfaces;
using RepositoryService.Application.Models.Messages;
using System.Threading.Tasks;

namespace RepositoryService.Application.Services
{
    internal class OrdersService : IOrdersService
    {
        public async Task UpdateAsync(UpdateOrderItemsMessage order)
        {
        }
    }
}
