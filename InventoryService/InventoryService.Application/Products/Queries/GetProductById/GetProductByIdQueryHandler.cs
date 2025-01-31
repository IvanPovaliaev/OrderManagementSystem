using AutoMapper;
using InventoryService.Application.Products.DTO;
using InventoryService.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Handles the <see cref="GetProductByIdQuery"/> to retrieve a product by its unique identifier.
    /// </summary>
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductDTO?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var dbProduct = await _unitOfWork.ProductsRepository.GetAsync(request.Id);
            return _mapper.Map<ProductDTO>(dbProduct);
        }
    }
}
