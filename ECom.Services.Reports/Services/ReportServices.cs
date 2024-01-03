using ECom.Services.Reports.Data;
using ECom.Services.Reports.Models;
using ECom.Services.Reports.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Reports.Services
{
    public static class ReportServices
    {
        public static DailyReport FindDailyReport(DateOnly reportDate)
        {
            DailyReport dailyReport = DataAccess.Ins.DB.DailyReports.FirstOrDefault(u => u.Date == reportDate);

            if(dailyReport == null)
            {
                MonthlyReport monthlyReport = FindMonthlyReport(DateOnly.FromDateTime(TimeTruncate.TruncateToMonthStart(reportDate)));

                DailyReport newDailyReport = new DailyReport()
                {
                    Date = reportDate,
                    Income = 0,
                    Outcome = 0,
                    Profit = 0,
                    SoldQuantity = 0,
                    Month = monthlyReport.Month,
                };

                try
                {
                    DataAccess.Ins.DB.DailyReports.Add(newDailyReport);
                    DataAccess.Ins.DB.SaveChanges();
                    return newDailyReport;  
                }
                catch
                {
                    throw new Exception();
                }
            }
            else
            {
                return dailyReport;
            }
        }

        public static MonthlyReport FindMonthlyReport(DateOnly reportMonth) 
        {
            MonthlyReport monthlyReport = DataAccess.Ins.DB.MonthlyReports.FirstOrDefault(u => u.Month == reportMonth);

            if (monthlyReport == null)
            {
                YearlyReport yearlyReport = FindYearlyReport(DateOnly.FromDateTime(TimeTruncate.TruncateToYearStart(reportMonth)));

                MonthlyReport newMonthlyReport = new MonthlyReport()
                {
                    Month = reportMonth,
                    Income = 0,
                    Outcome = 0,
                    Profit = 0,
                    SoldQuantity = 0,
                    Year = yearlyReport.Year,
                };
                try
                {
                    DataAccess.Ins.DB.MonthlyReports.Add(newMonthlyReport);
                    DataAccess.Ins.DB.SaveChanges();
                    return newMonthlyReport;
                }
                catch
                {
                    throw new Exception();
                }
            }
            else
            {
                return monthlyReport;
            }
        }

        public static YearlyReport FindYearlyReport(DateOnly reportYear)
        {
            YearlyReport yearlyReport = DataAccess.Ins.DB.YearlyReports.FirstOrDefault(u => u.Year == reportYear);

            if (yearlyReport == null)
            {
                YearlyReport newYearlyReport = new YearlyReport()
                {
                    Year = reportYear,
                    Income = 0,
                    Outcome = 0,
                    Profit = 0,
                    SoldQuantity = 0,
                };
                try
                {
                    DataAccess.Ins.DB.YearlyReports.Add(newYearlyReport);
                    DataAccess.Ins.DB.SaveChanges();
                    return newYearlyReport;
                }
                catch
                {
                    throw new Exception();
                }
            }
            else
            {
                return yearlyReport;
            }
        }

        public static void UpdateReport(DateOnly reportDate)
        {
            DateOnly reportMonth = DateOnly.FromDateTime(TimeTruncate.TruncateToMonthStart(reportDate));

            MonthlyReport monthlyReport = FindMonthlyReport(reportMonth);

            monthlyReport.Profit = DataAccess.Ins.DB.DailyReports.Where(u => u.Month == reportMonth).Sum(i => i.Profit); 
            monthlyReport.Income = DataAccess.Ins.DB.DailyReports.Where(u => u.Month == reportMonth).Sum(i => i.Income); 
            monthlyReport.Outcome = DataAccess.Ins.DB.DailyReports.Where(u => u.Month == reportMonth).Sum(i => i.Outcome); 
            monthlyReport.SoldQuantity = DataAccess.Ins.DB.DailyReports.Where(u => u.Month == reportMonth).Sum(i => i.SoldQuantity);

            DataAccess.Ins.DB.SaveChanges();

            DateOnly reportYear = DateOnly.FromDateTime(TimeTruncate.TruncateToYearStart(reportDate));

            YearlyReport yearlyReport = FindYearlyReport(reportYear);

            yearlyReport.Profit = DataAccess.Ins.DB.MonthlyReports.Where(u => u.Year == reportYear).Sum(i => i.Profit); 
            yearlyReport.Income = DataAccess.Ins.DB.MonthlyReports.Where(u => u.Year == reportYear).Sum(i => i.Income); 
            yearlyReport.Outcome = DataAccess.Ins.DB.MonthlyReports.Where(u => u.Year == reportYear).Sum(i => i.Outcome); 
            yearlyReport.SoldQuantity = DataAccess.Ins.DB.MonthlyReports.Where(u => u.Year == reportYear).Sum(i => i.SoldQuantity);

            DataAccess.Ins.DB.SaveChanges();

        }
    }
}
