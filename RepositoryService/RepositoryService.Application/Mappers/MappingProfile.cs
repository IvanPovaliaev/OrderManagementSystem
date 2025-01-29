﻿using AutoMapper;
using RepositoryService.Application.Models;
using RepositoryService.Application.Models.Messages;
using RepositoryService.Application.Products.DTO;
using RepositoryService.Domain.Models;

namespace RepositoryService.Application.Mappers
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
