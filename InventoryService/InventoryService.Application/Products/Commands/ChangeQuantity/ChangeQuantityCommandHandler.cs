using InventoryService.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Products.Commands.ChangeQuantity
{
    /// <summary>
    /// Handles the <see cref="ChangeQuantityCommand"/> to update the quantity of a product in the system.
    /// </summary>
    public class ChangeQuantityCommandHandler : IRequestHandler<ChangeQuantityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeQuantityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ChangeQuantityCommand request, CancellationToken cancellationToken)
        {
            var dbProduct = await _unitOfWork.ProductsRepository.GetAsync(request.Id);
            dbProduct!.QuantityInStock += request.QuantityChange;
        }
    }
}
