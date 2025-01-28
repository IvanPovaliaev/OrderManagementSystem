using AutoMapper;
using RepositoryService.Application.Models;
using RepositoryService.Domain.Models;

namespace RepositoryService.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderDetailsDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderItemRequest, OrderItem>();

            CreateMap<CreateOrderMessage, Order>();

            CreateMap<Product, ProductDTO>();
        }
    }
}
