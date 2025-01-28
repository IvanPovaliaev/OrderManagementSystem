using MediatR;
using RepositoryService.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Application.Orders.Commands.ChangeOrderStatus
{
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
