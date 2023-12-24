using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Cart.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Receipt, ReceiptDto>();
            CreateMap<ReceiptDto, Receipt>();
        }
    }
}
