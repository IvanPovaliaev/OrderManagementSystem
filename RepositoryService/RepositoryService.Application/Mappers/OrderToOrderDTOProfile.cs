using AutoMapper;
using RepositoryService.Application.Models;
using RepositoryService.Domain.Models;

namespace RepositoryService.Application.Mappers
{
    public class OrderToOrderDTOProfile : Profile
    {
        public OrderToOrderDTOProfile()
        {
            CreateMap<Order, OrderDTO>();
        }
    }
}
