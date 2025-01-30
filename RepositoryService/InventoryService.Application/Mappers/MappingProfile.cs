using AutoMapper;
using InventoryService.Application.Models;
using InventoryService.Application.Models.Messages;
using InventoryService.Application.Products.DTO;
using InventoryService.Domain.Models;

namespace InventoryService.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderDetailsDTO>();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();

            CreateMap<CreateOrderMessage, Order>();

            CreateMap<Product, ProductDTO>();
        }
    }
}
