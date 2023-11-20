using AutoMapper;
using Dto.AuthDto;
using Dto.ProductDto;
using ECom.Services.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Auth.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}
