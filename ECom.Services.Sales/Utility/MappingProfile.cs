using AutoMapper;
using Dto.OrderDto;
using Dto.ProductDto;
using ECom.Services.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Sales.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            

        }
    }
}
