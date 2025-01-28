using AutoMapper;
using RepositoryService.Application.Interfaces;
using RepositoryService.Application.Models;
using RepositoryService.Domain.Interfaces;
using RepositoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryService.Application.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public OrdersService(IOrdersRepository ordersRepository, IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateOrderMessage newOrderMessage)
        {
            var newOrder = _mapper.Map<Order>(newOrderMessage);

            foreach (var item in newOrder.Items)
            {
                await _productsService.ChangeQuantityBy(item.ProductId, -item.Quantity);
            }

            await _ordersRepository.AddAsync(newOrder);
        }

        public async Task<ICollection<OrderDTO>> GetAllAsync()
        {
            var dbOrders = await _ordersRepository.GetAllAsync();
            return dbOrders.Select(_mapper.Map<OrderDTO>).ToArray();
        }

        public async Task<OrderDetailsDTO?> GetAsync(Guid id)
        {
            var dbOrder = await _ordersRepository.GetAsync(id);
            return _mapper.Map<OrderDetailsDTO>(dbOrder);
        }

        public async Task CancelAsync(Guid id)
        {
            var dbOrder = await _ordersRepository.GetAsync(id);

            if (dbOrder is null)
            {
                return;
            }

            dbOrder.Status = OrderStatus.Cancelled;
            await _ordersRepository.UpdateAsync(dbOrder);
        }

        public async Task ChangeStatusAsync(Guid id, OrderStatus newStatus)
        {
            var dbOrder = await _ordersRepository.GetAsync(id);

            if (dbOrder is null)
            {
                return;
            }

            dbOrder.Status = newStatus;
            await _ordersRepository.UpdateAsync(dbOrder);
        }
    }
}
