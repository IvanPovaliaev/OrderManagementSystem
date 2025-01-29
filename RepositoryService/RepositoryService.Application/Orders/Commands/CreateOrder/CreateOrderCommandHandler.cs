using AutoMapper;
using MediatR;
using RepositoryService.Application.Products.Commands.ChangeQuantity;
using RepositoryService.Domain.Interfaces;
using RepositoryService.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Application.Orders.Commands.CreateOrder
{
    /// <summary>
    /// Handles the <see cref="CreateOrderCommand"/> to create a new order.
    /// </summary>
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public CreateOrderCommandHandler(IOrdersRepository ordersRepository, IMapper mapper, ISender sender)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
            _sender = sender;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = _mapper.Map<Order>(request.Message);

            foreach (var item in newOrder.Items)
            {
                var command = new ChangeQuantityCommand(item.ProductId, -item.Quantity);
                await _sender.Send(command);
            }

            await _ordersRepository.AddAsync(newOrder);
        }
    }
}
