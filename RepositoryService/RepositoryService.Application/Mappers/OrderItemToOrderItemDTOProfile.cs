using AutoMapper;
using RepositoryService.Application.Models;
using RepositoryService.Domain.Models;

namespace RepositoryService.Application.Mappers
{
    public class OrderItemToOrderItemDTOProfile : Profile
    {
        public OrderItemToOrderItemDTOProfile()
        {
            CreateMap<OrderItem, OrderItemDTO>();
        }
    }
}
