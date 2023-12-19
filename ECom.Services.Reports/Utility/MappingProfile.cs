using AutoMapper;
using Dto.ReportDto;
using ECom.Services.Reports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Reports.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<YearlyReport, YearlyReportDto>();
            CreateMap<YearlyReportDto, YearlyReport>();
            CreateMap<MonthlyReport, MonthlyReportDto>();
            CreateMap<MonthlyReportDto, MonthlyReport>();
            CreateMap<DailyReport, DailyReportDto>();
            CreateMap<DailyReportDto, DailyReport>();
        }
    }
}
