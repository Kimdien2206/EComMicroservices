using AutoMapper;
using Dto.ForecastDto;
using Ecom.Services.Forecasts.Models;

namespace ECom.Services.Forecasts.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Forecast, ForecastDto>();
            CreateMap<ForecastDto, Forecast>();
        }
    }
}
