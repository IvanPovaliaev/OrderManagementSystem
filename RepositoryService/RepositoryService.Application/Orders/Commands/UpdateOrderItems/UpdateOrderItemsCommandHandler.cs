using AutoMapper;
using MediatR;
using RepositoryService.Application.Products.Commands.ChangeQuantity;
using RepositoryService.Domain.Interfaces;
using RepositoryService.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Application.Orders.Commands.UpdateOrderItems
{
    /// <summary>
    /// Handles the <see cref="UpdateOrderItemsCommand"/> to update order items.
    /// </summary>
    public class UpdateOrderItemsCommandHandler : IRequestHandler<UpdateOrderItemsCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public UpdateOrderItemsCommandHandler(IOrdersRepository ordersRepository, IMapper mapper, ISender sender)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
            _sender = sender;
        }

        public async Task Handle(UpdateOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var dbOrder = await _ordersRepository.GetAsync(request.Message.Id);

            var addedItems = request.Message.AddedItems
                                            .Select(_mapper.Map<OrderItem>);
            var updatedItems = request.Message.UpdatedItems;
            var removedProductIds = request.Message.RemovedProductIds;

            await UpdateItems();
            await RemoveItems();
            await AddItems();

            dbOrder.TotalItems = request.Message.TotalItems;
            dbOrder.TotalPrice = request.Message.TotalPrice;

            await _ordersRepository.UpdateAsync(dbOrder);

            async Task RemoveItems()
            {
                foreach (var productId in removedProductIds)
                {
                    var itemIndex = dbOrder.Items.FindIndex(item => item.ProductId == productId);

                    var oldItem = dbOrder.Items[itemIndex];

                    await _sender.Send(new ChangeQuantityCommand(oldItem.ProductId, oldItem.Quantity));

                    dbOrder.Items.RemoveAt(itemIndex);
                }
            }

            async Task UpdateItems()
            {
                foreach (var item in updatedItems)
                {
                    var currentItem = dbOrder.Items.FirstOrDefault(dbOrder => dbOrder.ProductId == item.ProductId);

                    var quantityChange = currentItem!.Quantity - item.Quantity;

                    currentItem.Quantity = item.Quantity;

                    await _sender.Send(new ChangeQuantityCommand(item.ProductId, quantityChange));
                }
            }

            async Task AddItems()
            {
                foreach (var item in addedItems)
                {
                    await _sender.Send(new ChangeQuantityCommand(item.ProductId, -item.Quantity));
                }

                dbOrder!.Items.AddRange(addedItems);
            }
        }
    }
}
