using AutoMapper;
using Microsoft.Extensions.Options;
using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Models;
using OrderManagementService.Application.Models.Messages;
using OrderManagementService.Application.Models.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementService.Application.Services
{
    /// <summary>
    /// Service to interact with the repository service for retrieving information.
    /// This class implements the <see cref="IOrdersService"/> interface.
    /// </summary>
    internal class OrderService : IOrdersService
    {
        private readonly IRepositoryServiceClient _repositoryServiceClient;
        private readonly IMapper _mapper;
        private readonly IMessageBrokerPublisher _messageBrokerPublisher;
        private readonly OrdersOptions _ordersOptions;

        public OrderService(IRepositoryServiceClient repositoryServiceClient, IMapper mapper, IOptions<OrdersOptions> ordersOptions, IMessageBrokerPublisher messageBrokerPublisher)
        {
            _repositoryServiceClient = repositoryServiceClient;
            _mapper = mapper;
            _ordersOptions = ordersOptions.Value;
            _messageBrokerPublisher = messageBrokerPublisher;
        }

        public async Task<bool> CreateAsync(NewOrderDTO newOrder)
        {
            foreach (var itemDTO in newOrder.Items)
            {
                if (!await IsItemCorrect(itemDTO))
                {
                    return false;
                }
            }

            var routingKey = "order.create";
            var message = _mapper.Map<CreateOrderMessage>(newOrder) with
            {
                StoreUntil = DateTime.UtcNow.AddDays(_ordersOptions.StorageDays),
                TotalItems = newOrder.Items.Sum(item => item.Quantity),
                TotalPrice = newOrder.Items.Sum(item => item.Quantity * item.UnitPrice)
            };

            await _messageBrokerPublisher.PublishAsync(routingKey, message);

            return true;
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

            if (!CanBeCanceled(order))
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
            return currentStatus != newStatus && newStatus != OrderStatus.Cancelled;
        }

        private bool CanBeCanceled(OrderDTO order)
        {
            return order.Status != OrderStatus.Cancelled;
        }

        private async Task<bool> IsItemCorrect(OrderItemDTO item)
        {
            var productDb = await _repositoryServiceClient.GetProductByIdAsync(item.ProductId);

            if (productDb == null)
            {
                return false;
            }

            return item.Quantity <= productDb.QuantityInStock;
        }
    }
}
