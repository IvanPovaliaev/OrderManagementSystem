using AutoMapper;
using MediatR;
using RepositoryService.Application.Products.DTO;
using RepositoryService.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Application.Products.Queries.GetProductById
{
    /// <summary>
    /// Handles the <see cref="GetProductByIdQuery"/> to retrieve a product by its unique identifier.
    /// </summary>
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO?>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        public async Task<ProductDTO?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var dbProduct = await _productsRepository.GetAsync(request.Id);
            return _mapper.Map<ProductDTO>(dbProduct);
        }
    }
}
