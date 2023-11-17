using AutoMapper;
using Dto.ProductDto;
using ECom.Gateway.Models;

namespace ECom.Gateway.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Discount, DiscountDto>();
            CreateMap<DiscountDto, Discount>();
            CreateMap<Collection, CollectionDto>();
            CreateMap<CollectionDto, Collection>();
        }
    }
}
