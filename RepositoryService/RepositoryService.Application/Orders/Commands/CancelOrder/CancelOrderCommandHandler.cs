using MediatR;
using RepositoryService.Application.Products.Commands.ChangeQuantity;
using RepositoryService.Domain.Interfaces;
using RepositoryService.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Application.Orders.Commands.CancelOrder
{
    /// <summary>
    /// Handles the <see cref="CancelOrderCommand"/> to cancel an order.
    /// </summary>
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ISender _sender;

        public CancelOrderCommandHandler(IOrdersRepository ordersRepository, ISender sender)
        {
            _ordersRepository = ordersRepository;
            _sender = sender;
        }


        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var dbOrder = await _ordersRepository.GetAsync(request.Id);

            if (dbOrder is null)
            {
                return;
            }

            dbOrder.Status = OrderStatus.Cancelled;

            foreach (var item in dbOrder.Items)
            {
                var command = new ChangeQuantityCommand()
                {
                    Id = item.ProductId,
                    QuantityChange = item.Quantity
                };

                await _sender.Send(command);
            }

            await _ordersRepository.UpdateAsync(dbOrder);
        }
    }
}
