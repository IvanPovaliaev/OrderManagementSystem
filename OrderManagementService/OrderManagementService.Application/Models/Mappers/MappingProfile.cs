using AutoMapper;
using OrderManagementService.Application.Models.Messages;

namespace OrderManagementService.Application.Models.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ChangeOrderStatusDTO, OrderStatusChangedMessage>();
            CreateMap<NewOrderDTO, CreateOrderMessage>();
            CreateMap<UpdateOrderDTO, UpdateOrderMessage>();
        }
    }
}
