using AutoMapper;
using Dto.ReportDto;
using ECom.Services.Reports.Models;

namespace ECom.Services.Reports.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<YearlyReport, YearlyReportDto>();
            CreateMap<YearlyReportDto, YearlyReport>();
            CreateMap<MonthlyReport, MonthlyReportDto>();
            CreateMap<MonthlyReportDto, MonthlyReport>();
            CreateMap<DailyReport, DailyReportDto>();
            CreateMap<DailyReportDto, DailyReport>();
            CreateMap<DailyReportDetail, DailyReportDetailDto>();
            CreateMap<DailyReportDetailDto, DailyReportDetail>();
        }
    }
}
