using AutoMapper;
using Dto.ProductDto;
using E_commerce_shop_2.Models;
using ECom.Services.Products.Models;

namespace ECom.Services.Products.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductItem, ProductItemDto>();
            CreateMap<ProductItemDto, ProductItem>();
            CreateMap<Discount, DiscountDto>();
            CreateMap<DiscountDto, Discount>();
            CreateMap<Collection, CollectionDto>();
            CreateMap<CollectionDto, Collection>();
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
            CreateMap<HaveTag, HaveTagDto>();
            CreateMap<HaveTagDto, HaveTag>();

            CreateMap<VoucherDto, Voucher>();
            CreateMap<Voucher, VoucherDto>();
        }
    }
}
