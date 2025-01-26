using AutoMapper;
using RepositoryService.Application.Models;
using RepositoryService.Domain.Models;

namespace RepositoryService.Application.Mappers
{
    public class ProductToProductDTOProfile : Profile
    {
        public ProductToProductDTOProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
