﻿using AutoMapper;
using InventoryService.Application.Products.DTO;
using InventoryService.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Products.Queries.GetAllProducts
{
    /// <summary>
    /// Handles the <see cref="GetAllProductsQuery"/> to retrieve all products from the system.
    /// </summary>
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var dbProducts = await _unitOfWork.ProductsRepository.GetAllAsync();
            return dbProducts.Select(_mapper.Map<ProductDTO>);
        }
    }
}
