using InventoryService.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public ChangeOrderStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var dbOrder = await _unitOfWork.OrdersRepository.GetAsync(request.Id);

            if (dbOrder is null)
            {
                return;
            }

            dbOrder.Status = request.NewStatus;
            await _unitOfWork.OrdersRepository.UpdateAsync(dbOrder);
        }
    }
}
