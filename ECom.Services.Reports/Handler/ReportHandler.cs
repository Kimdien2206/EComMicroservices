using AutoMapper;
using Dto.ReportDto;
using ECom.Services.Reports.Data;
using ECom.Services.Reports.Models;
using ECom.Services.Reports.Services;
using ECom.Services.Reports.Utility;
using Messages;
using Messages.ImportingMessages;
using Messages.ReceiptMessages;
using Messages.ReportMessages;
using Microsoft.EntityFrameworkCore;
using NServiceBus.Logging;

namespace ECom.Services.Reports.Handler
{
    public class ReportHandler :
        IHandleMessages<GetYearlyReport>,
        IHandleMessages<ReceiptPaid>,
        IHandleMessages<GetAllDailyDetailReport>,
        IHandleMessages<ImportingCreated>
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

            if (message.Year == null)
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

        public async Task Handle(ReceiptPaid message, IMessageHandlerContext context)
        {
            log.Info("Receive event");
            if (message.PaidDate == DateOnly.MinValue || message.Income == 0)
            {
                log.Info("Missing parameter when handle ReceiptPaid event");
            }
            else
            {
                DailyReport paidDate = ReportServices.FindDailyReport(message.PaidDate);

                paidDate.Income += message.Income;
                paidDate.Profit += message.Income;

                await DataAccess.Ins.DB.SaveChangesAsync(context.CancellationToken);

                ReportServices.UpdateReport(message.PaidDate);
            }
        }
        
        public async Task Handle(ImportingCreated message, IMessageHandlerContext context)
        {
            log.Info("Receive event");
            if (message.Date == DateOnly.MinValue || message.TotalCost == 0)
            {
                log.Info("Missing parameter when handle ReceiptPaid event");
            }
            else
            {
                try
                {
                    DailyReport paidDate = ReportServices.FindDailyReport(message.Date);

                    paidDate.Outcome += (long)message.TotalCost;
                    paidDate.Profit -= (long)message.TotalCost;

                    await DataAccess.Ins.DB.SaveChangesAsync(context.CancellationToken);

                    ReportServices.UpdateReport(message.Date);
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                }
            }
        }

        public Task Handle(GetAllDailyDetailReport message, IMessageHandlerContext context)
        {
            var respond = new GetAllDailyDetailReportSaga();

            try
            {
                var dailyDetailRps = DataAccess.Ins.DB.DailyReportDetails.ToList();

                var forecastRps = dailyDetailRps.Select(dailyDetailRp => mapper.Map<DailyReportDetailDto>(dailyDetailRp)).ToList();

                respond.Forecasts = forecastRps;
                respond.SagaId = message.SagaId;
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                log.Error(ex.StackTrace);
            }

            context.Send(respond).ConfigureAwait(false);
            return Task.CompletedTask;
        }
    }
}

