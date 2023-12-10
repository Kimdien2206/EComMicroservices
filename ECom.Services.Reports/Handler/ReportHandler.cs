using AutoMapper;
using Dto.OrderDto;
using Dto.ReportDto;
using ECom.Services.Reports.Data;
using ECom.Services.Reports.Models;
using ECom.Services.Reports.Utility;
using Messages;
using Messages.OrderMessages;
using Messages.ProductMessages;
using Messages.ReportMessages;
using Microsoft.EntityFrameworkCore;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Reports.Handler
{
    public class ReportHandler :
        IHandleMessages<GetYearlyReport>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<ReportHandler>();

        public ReportHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(GetYearlyReport message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<YearlyReportDto>();
            
            if(message.Year == null)
            {
                responseMessage.ErrorCode = 400;
                log.Info("Missing parameter");
            }
            else
            {
                try
                {
                    List<YearlyReport> reports = DataAccess.Ins.DB.YearlyReports
                        .Include(yearlyReports => yearlyReports.MonthlyReports)
                            .ThenInclude(monthlyReports => monthlyReports.DailyReports)
                        .Where(u => u.Year == message.Year).ToList();

                    responseMessage.responseData = reports.Select(report => mapper.Map<YearlyReportDto>(report));
                    responseMessage.ErrorCode = 200;
                    log.Info("Response sent");
                }
                catch
                {
                    log.Info("Something went wrong");
                    responseMessage.ErrorCode = 500;
                }

            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }
    }
}

