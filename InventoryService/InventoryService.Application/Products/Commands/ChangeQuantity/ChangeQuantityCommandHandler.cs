using MediatR;
using System.Threading.Tasks;
using System.Threading;
using InventoryService.Domain.Interfaces;

namespace InventoryService.Application.Products.Commands.ChangeQuantity
{
    /// <summary>
    /// Handles the <see cref="ChangeQuantityCommand"/> to update the quantity of a product in the system.
    /// </summary>
    public class ChangeQuantityCommandHandler : IRequestHandler<ChangeQuantityCommand>
    {
        private readonly IProductsRepository _productsRepository;

        public ChangeQuantityCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task Handle(ChangeQuantityCommand request, CancellationToken cancellationToken)
        {
            var dbProduct = await _productsRepository.GetAsync(request.Id);
            dbProduct!.QuantityInStock += request.QuantityChange;
        }
    }
}
