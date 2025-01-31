using InventoryService.Application.Products.Commands.ChangeQuantity;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Orders.Commands.CancelOrder
{
    /// <summary>
    /// Handles the <see cref="CancelOrderCommand"/> to cancel an order.
    /// </summary>
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISender _sender;

        public CancelOrderCommandHandler(IUnitOfWork unitOfWork, ISender sender)
        {
            _unitOfWork = unitOfWork;
            _sender = sender;
        }

        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var dbOrder = await _unitOfWork.OrdersRepository.GetAsync(request.Id);

            if (dbOrder is null)
            {
                return;
            }

            dbOrder.Status = OrderStatus.Cancelled;

            foreach (var item in dbOrder.Items)
            {
                var command = new ChangeQuantityCommand(item.ProductId, item.Quantity);
                await _sender.Send(command);
            }

            await _unitOfWork.OrdersRepository.UpdateAsync(dbOrder);
        }
    }
}
