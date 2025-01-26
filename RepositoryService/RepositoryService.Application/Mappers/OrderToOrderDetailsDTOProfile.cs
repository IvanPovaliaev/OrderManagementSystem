using AutoMapper;
using RepositoryService.Application.Models;
using RepositoryService.Domain.Models;

namespace RepositoryService.Application.Mappers
{
    public class OrderToOrderDetailsDTOProfile : Profile
    {
        public OrderToOrderDetailsDTOProfile()
        {
            CreateMap<Order, OrderDetailsDTO>();
        }
    }
}
