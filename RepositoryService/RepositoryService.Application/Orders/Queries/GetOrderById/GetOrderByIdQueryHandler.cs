using AutoMapper;
using MediatR;
using RepositoryService.Application.Models;
using RepositoryService.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailsDTO?>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderDetailsDTO?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var dbOrder = await _ordersRepository.GetAsync(request.Id);
            return _mapper.Map<OrderDetailsDTO>(dbOrder);
        }
    }
}
