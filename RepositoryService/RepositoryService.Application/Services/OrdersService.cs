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
        private readonly IMapper _mapper;

        public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
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
    }
}
