﻿using InventoryService.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Orders.Commands.ChangeOrderStatus
{
    /// <summary>
    /// Handles the <see cref="ChangeOrderStatusCommand"/> to change the status of an order.
    /// </summary>
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand>
    {
        private readonly IOrdersRepository _ordersRepository;

        public ChangeOrderStatusCommandHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var dbOrder = await _ordersRepository.GetAsync(request.Id);

            if (dbOrder is null)
            {
                return;
            }

            dbOrder.Status = request.NewStatus;
            await _ordersRepository.UpdateAsync(dbOrder);
        }
    }
}
