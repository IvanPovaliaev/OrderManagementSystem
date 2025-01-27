using AutoMapper;
using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Models;
using OrderManagementService.Application.Models.Messages;
using OrderManagementService.Infrastructure.RepositoryService.Models;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.Application.Services
{
    internal class OrderService : IOrdersService
    {
        private readonly IRepositoryServiceClient _repositoryServiceClient;
        private readonly IMapper _mapper;
        private readonly IMessageBrokerPublisher _messageBrokerPublisher;

        public OrderService(IRepositoryServiceClient repositoryServiceClient, IMapper mapper, IMessageBrokerPublisher messageBrokerPublisher)
        {
            _repositoryServiceClient = repositoryServiceClient;
            _mapper = mapper;
            _messageBrokerPublisher = messageBrokerPublisher;
        }

        public async Task<bool> ChangeStatusAsync(ChangeOrderStatusDTO order)
        {
            var orderDb = await _repositoryServiceClient.GetOrderByIdAsync(order.Id);

            if (!IsStatusCanBeChanged(orderDb.Status, order.NewStatus))
            {
                return false;
            }

            var routingKey = "order.change.status";
            var message = _mapper.Map<OrderStatusChangedMessage>(order);
            await _messageBrokerPublisher.PublishAsync(routingKey, message);

            return true;
        }

        public async Task<bool> CancelAsync(Guid id)
        {
            var order = await _repositoryServiceClient.GetOrderByIdAsync(id);

            if (!IsCanBeCanceled(order))
            {
                return false;
            }

            var routingKey = "order.cancel";
            await _messageBrokerPublisher.PublishAsync(routingKey, id);

            return true;
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            return await _repositoryServiceClient.GetOrderByIdAsync(id) is not null;
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
