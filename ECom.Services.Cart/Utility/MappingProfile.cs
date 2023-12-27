using AutoMapper;
using Dto.CartDto;
using ECom.Services.Carts.Models;

namespace ECom.Services.Carts.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();
        }
    }
}
