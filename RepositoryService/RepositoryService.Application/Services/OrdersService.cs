using AutoMapper;
using MediatR;
using RepositoryService.Application.Interfaces;
using RepositoryService.Application.Models.Messages;
using RepositoryService.Application.Products.Commands.ChangeQuantity;
using RepositoryService.Domain.Interfaces;
using RepositoryService.Domain.Models;
using System;
using System.Threading.Tasks;

namespace RepositoryService.Application.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public OrdersService(IOrdersRepository ordersRepository, ISender sender, IMapper mapper)
        {
            _sender = sender;
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateOrderMessage newOrderMessage)
        {
            var newOrder = _mapper.Map<Order>(newOrderMessage);

            foreach (var item in newOrder.Items)
            {
                var command = new ChangeQuantityCommand()
                {
                    Id = item.Id,
                    QuantityChange = -item.Quantity
                };
                await _sender.Send(command);
            }

            await _ordersRepository.AddAsync(newOrder);
        }

        public async Task UpdateAsync(UpdateOrderMessage order)
        {
            var dbOrder = await _ordersRepository.GetAsync(order.Id);

            if (dbOrder is null)
            {
                return;
            }
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
