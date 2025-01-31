using AutoMapper;
using InventoryService.Application.Models;
using InventoryService.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Orders.Queries.GetAllOrders
{
    /// <summary>
    /// Handles the <see cref="GetAllOrdersQuery"/> to retrieve all orders from the system.
    /// </summary>
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var dbOrders = await _unitOfWork.OrdersRepository.GetAllAsync();
            return dbOrders.Select(_mapper.Map<OrderDTO>);
        }
    }
}
