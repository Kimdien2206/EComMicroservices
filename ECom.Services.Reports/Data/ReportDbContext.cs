using ECom.Services.Reports.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECom.Services.Reports.Data
{
    public class ReportDbContext : DbContext
    {
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<MonthlyReport> MonthlyReports { get; set; }
        public DbSet<YearlyReport> YearlyReports { get; set; }

        public DbSet<DailyReportDetail> DailyReportDetails { get; set; }

        public ReportDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true)
                    .AddEnvironmentVariables();

            IConfiguration config = builder.Build();

            string connect = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connect);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveColumnType("Date");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YearlyReport>().HasData(
                new YearlyReport()
                {
                    Year = DateOnly.Parse("2023/1/1"),
                    Income = 5000000000,
                    Outcome = 490000800,
                    Profit = 4903928830,
                    SoldQuantity = 50000
                }
                );
            modelBuilder.Entity<MonthlyReport>().HasData(
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/1/1"),
                    Income = 50000000,
                    Outcome = 4000800,
                    Profit = 4328830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/2/1"),
                    Income = 4200000,
                    Outcome = 40800,
                    Profit = 432830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/3/1"),
                    Income = 55808000,
                    Outcome = 4000800,
                    Profit = 4328830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/4/1"),
                    Income = 5080000,
                    Outcome = 4005800,
                    Profit = 43258830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/5/1"),
                    Income = 23000000,
                    Outcome = 5140800,
                    Profit = 3288306,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/6/1"),
                    Income = 542540000,
                    Outcome = 4133500,
                    Profit = 4328830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/7/1"),
                    Income = 41360000,
                    Outcome = 7530800,
                    Profit = 4328830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/8/1"),
                    Income = 1430000,
                    Outcome = 300800,
                    Profit = 3228830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/9/1"),
                    Income = 32320000,
                    Outcome = 400800,
                    Profit = 4322830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/10/1"),
                    Income = 223300000,
                    Outcome = 53658800,
                    Profit = 46568830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/11/1"),
                    Income = 50000000,
                    Outcome = 4000800,
                    Profit = 4328830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                },
                new MonthlyReport()
                {
                    Month = DateOnly.Parse("2023/12/1"),
                    Income = 50000000,
                    Outcome = 4000800,
                    Profit = 4328830,
                    SoldQuantity = 500,
                    Year = DateOnly.Parse("2023/1/1")
                });
            modelBuilder.Entity<DailyReport>().HasData(
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/1"),
                    Income = 500000,
                    Outcome = 80000,
                    Profit = 400830,
                    SoldQuantity = 5,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/2"),
                    Income = 5520100,
                    Outcome = 400800,
                    Profit = 4328830,
                    SoldQuantity = 50,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/3"),
                    Income = 2014000,
                    Outcome = 442500,
                    Profit = 1524830,
                    SoldQuantity = 20,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/4"),
                    Income = 2140000,
                    Outcome = 210800,
                    Profit = 1258830,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/5"),
                    Income = 32500000,
                    Outcome = 4000800,
                    Profit = 36228830,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/6"),
                    Income = 9600000,
                    Outcome = 520800,
                    Profit = 9218830,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/7"),
                    Income = 12025200,
                    Outcome = 4042800,
                    Profit = 8518830,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/8"),
                    Income = 54740000,
                    Outcome = 41200,
                    Profit = 2418830,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/9"),
                    Income = 12400000,
                    Outcome = 440800,
                    Profit = 1423830,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/10"),
                    Income = 14250000,
                    Outcome = 456486,
                    Profit = 8451246,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/11"),
                    Income = 4675652,
                    Outcome = 656264,
                    Profit = 6542642,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/12"),
                    Income = 64865224,
                    Outcome = 864564,
                    Profit = 65634266,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/13"),
                    Income = 4263164,
                    Outcome = 6542164,
                    Profit = 6464568,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/14"),
                    Income = 456462161,
                    Outcome = 756576,
                    Profit = 56746264,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/15"),
                    Income = 45642621,
                    Outcome = 5648646,
                    Profit = 546465,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/16"),
                    Income = 54642562,
                    Outcome = 4566456,
                    Profit = 54648626,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/17"),
                    Income = 56426321,
                    Outcome = 564568,
                    Profit = 26456876,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/18"),
                    Income = 45621654,
                    Outcome = 456878,
                    Profit = 5464562,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/19"),
                    Income = 126126568,
                    Outcome = 5462161,
                    Profit = 7865612,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/20"),
                    Income = 4562166,
                    Outcome = 45642,
                    Profit = 4564566,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/21"),
                    Income = 4564876,
                    Outcome = 126456,
                    Profit = 2134566,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/22"),
                    Income = 56766754,
                    Outcome = 937388,
                    Profit = 35835677,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/23"),
                    Income = 35675476,
                    Outcome = 465849,
                    Profit = 763457,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/24"),
                    Income = 4363464,
                    Outcome = 400800,
                    Profit = 4328830,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/25"),
                    Income = 2342351,
                    Outcome = 542554,
                    Profit = 2312424,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/26"),
                    Income = 23523566,
                    Outcome = 234241,
                    Profit = 5474724,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/27"),
                    Income = 24754645,
                    Outcome = 2525563,
                    Profit = 3135153,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/28"),
                    Income = 23564436,
                    Outcome = 2352546,
                    Profit = 4564754,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/29"),
                    Income = 3463467,
                    Outcome = 3457378,
                    Profit = 3453253,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                },
                new DailyReport()
                {
                    Date = DateOnly.Parse("2023/12/30"),
                    Income = 2365464,
                    Outcome = 3464685,
                    Profit = 3452352,
                    SoldQuantity = 500,
                    Month = DateOnly.Parse("2023/12/1")
                }
                );

            modelBuilder.Entity<DailyReportDetail>().HasData(
                GenerateMockData()
                );
        }

        static List<DailyReportDetail> GenerateMockData()
        {
            var startDate = DateOnly.Parse("2023/12/1");
            var endDate = startDate.AddDays(30); // assuming one year of data

            var random = new Random();
            var mockData = new List<DailyReportDetail>();

            var idCounter = 1;

            for (var currentDate = startDate; currentDate < endDate; currentDate = currentDate.AddDays(1))
            {
                // Replace the logic below with your own data generation logic
                var quantitySold = random.Next(1, 20); // adjust range as needed

                mockData.Add(new DailyReportDetail
                {
                    Id = idCounter++,
                    Date = currentDate,
                    ProductId = 1,  // Replace with your actual product ID
                    Quantity = quantitySold
                });
            }

            return mockData;
        }
    }
}
