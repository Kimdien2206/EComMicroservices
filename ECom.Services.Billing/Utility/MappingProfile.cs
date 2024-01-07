using AutoMapper;
using Dto.ReceiptDto;
using Dto.ProductDto;
using ECom.Services.Billing.Models;
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
            CreateMap<Receipt, ReceiptDto>();
            CreateMap<ReceiptDto, Receipt>();
            CreateMap<Receipt, ReceiptCreateDto>();
            CreateMap<ReceiptCreateDto, Receipt>();
        }
    }
}
