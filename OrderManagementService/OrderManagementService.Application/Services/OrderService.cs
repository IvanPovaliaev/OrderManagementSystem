using AutoMapper;
using Microsoft.Extensions.Options;
using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Models;
using OrderManagementService.Application.Models.DTOs;
using OrderManagementService.Application.Models.Messages;
using OrderManagementService.Application.Models.Options;
using System;
using System.Collections.Generic;
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
        private readonly IInventoryServiceClient _repositoryServiceClient;
        private readonly IMapper _mapper;
        private readonly IMessageBrokerPublisher _messageBrokerPublisher;
        private readonly OrdersOptions _ordersOptions;
        private readonly RabbitMQOptions _rabbitOptions;

        public OrderService(IInventoryServiceClient repositoryServiceClient, IMapper mapper, IOptions<OrdersOptions> ordersOptions, IOptions<RabbitMQOptions> rabbitMQOptions, IMessageBrokerPublisher messageBrokerPublisher)
        {
            _repositoryServiceClient = repositoryServiceClient;
            _mapper = mapper;
            _rabbitOptions = rabbitMQOptions.Value;
            _ordersOptions = ordersOptions.Value;
            _messageBrokerPublisher = messageBrokerPublisher;
        }

        public async Task<bool> CreateAsync(NewOrderDTO newOrder)
        {
            foreach (var item in newOrder.Items)
            {
                var isItemCorrect = await IsItemCorrectAsync(item, item.Quantity);
                if (!isItemCorrect)
                {
                    return false;
                }
            }

            var routingKey = _rabbitOptions.CreateOrderRoutingKey;
            var message = _mapper.Map<CreateOrderMessage>(newOrder) with
            {
                StoreUntil = DateTime.UtcNow.AddDays(_ordersOptions.StorageDays),
                TotalItems = newOrder.Items.Sum(item => item.Quantity),
                TotalPrice = newOrder.Items.Sum(item => item.Quantity * item.UnitPrice)
            };

            await _messageBrokerPublisher.PublishAsync(routingKey, message);

            return true;
        }

        public async Task<bool> UpdateItemsAsync(UpdateOrderItemsDTO order)
        {
            var orderDb = await _repositoryServiceClient.GetOrderByIdAsync(order.Id);

            if (orderDb is null)
            {
                return false;
            }

            var newItems = order.Items;
            var currentItems = orderDb.Items.ToDictionary(i => i.ProductId);
            var addedItems = new List<OrderItemDTO>();
            var updatedItems = new List<OrderItemDTO>();

            foreach (var item in newItems)
            {
                if (!currentItems.TryGetValue(item.ProductId, out var existingItem))
                {
                    var isItemCorrect = await IsItemCorrectAsync(item, item.Quantity);
                    if (!isItemCorrect)
                    {
                        return false;
                    }

                    addedItems.Add(item);
                }
                else if (existingItem.Quantity != item.Quantity)
                {
                    var quantityChange = item.Quantity - existingItem.Quantity;

                    if (quantityChange > 0 && !await IsItemCorrectAsync(item, quantityChange))
                    {
                        return false;
                    }

                    updatedItems.Add(item);
                }

                currentItems.Remove(item.ProductId);
            }

            var removedProductsId = currentItems.Values
                                                .Select(i => i.ProductId)
                                                .ToList();

            var routingKey = _rabbitOptions.UpdateOrderItemsRoutingKey;
            var message = new UpdateOrderItemsMessage
            {
                Id = order.Id,
                AddedItems = addedItems,
                UpdatedItems = updatedItems,
                RemovedProductIds = removedProductsId,
                TotalItems = addedItems.Sum(item => item.Quantity) + updatedItems.Sum(item => item.Quantity),
                TotalPrice = addedItems.Sum(item => item.Quantity * item.UnitPrice) +
                                                    updatedItems.Sum(item => item.Quantity * item.UnitPrice)
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

            var routingKey = _rabbitOptions.ChangeStatusOrderRoutingKey;
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

            var routingKey = _rabbitOptions.CancelOrderRoutingKey;
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

        private bool CanBeCanceled(OrderDTO order) => order.Status != OrderStatus.Cancelled;

        private async Task<bool> IsItemCorrectAsync(OrderItemDTO item, int quantityChange)
        {
            var productDb = await _repositoryServiceClient.GetProductByIdAsync(item.ProductId);

            if (productDb == null || quantityChange > productDb.QuantityInStock)
            {
                return false;
            }

            return true;
        }
    }
}
