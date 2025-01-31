﻿using AutoMapper;
using InventoryService.Application.Models;
using InventoryService.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Orders.Queries.GetOrderById
{
    /// <summary>
    /// Handles the <see cref="GetOrderByIdQuery"/> to retrieve an order by its unique identifier.
    /// </summary>
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailsDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDetailsDTO?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var dbOrder = await _unitOfWork.OrdersRepository.GetAsync(request.Id);
            return _mapper.Map<OrderDetailsDTO>(dbOrder);
        }
    }
}
