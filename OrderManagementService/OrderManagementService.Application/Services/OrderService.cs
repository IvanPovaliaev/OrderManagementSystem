using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Models;
using OrderManagementService.Infrastructure.RepositoryService.Models;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.Application.Services
{
    internal class OrderService : IOrdersService
    {
        private readonly IRepositoryServiceClient _repositoryServiceClient;
        public OrderService(IRepositoryServiceClient repositoryServiceClient)
        {
            _repositoryServiceClient = repositoryServiceClient;
        }

        public async Task<bool> ChangeStatusAsync(ChangeOrderStatusDTO order)
        {
            var orderDb = await _repositoryServiceClient.GetOrderByIdAsync(order.Id);

            if (!IsStatusCanBeChanged(orderDb.Status, order.NewStatus))
            {
                return false;
            }

            return true;
        }

        public async Task<bool> CancelAsync(Guid id)
        {
            var order = await _repositoryServiceClient.GetOrderByIdAsync(id);

            if (!IsCanBeCanceled(order))
            {
                return false;
            }

            //TO DO: тут отправляется событие в очередь на отмену заказа по id

            return true;
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            return await _repositoryServiceClient.GetOrderByIdAsync(id) is null;
        }

        private bool IsStatusCanBeChanged(OrderStatus currentStatus, OrderStatus newStatus)
        {
            return currentStatus != newStatus && newStatus != OrderStatus.Canceled;
        }

        private bool IsCanBeCanceled(OrderDTO order)
        {
            return order.Status != OrderStatus.Canceled;
        }
    }
}
