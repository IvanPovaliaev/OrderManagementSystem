using AutoMapper;
using RepositoryService.Application.Interfaces;
using RepositoryService.Application.Models;
using RepositoryService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryService.Application.Services
{
    internal class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<ProductDTO>> GetAllAsync()
        {
            var dbProducts = await _productsRepository.GetAllAsync();
            return dbProducts.Select(_mapper.Map<ProductDTO>).ToArray();
        }

        public async Task<ProductDTO?> GetAsync(Guid id)
        {
            var dbProduct = await _productsRepository.GetAsync(id);
            return _mapper.Map<ProductDTO>(dbProduct);
        }

        public async Task ChangeQuantityBy(Guid id, int quantity)
        {
            var dbProduct = await _productsRepository.GetAsync(id);
            dbProduct!.QuantityInStock += quantity;
        }
    }
}
