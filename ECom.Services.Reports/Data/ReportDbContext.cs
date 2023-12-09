using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECom.Services.Reports.Models;

namespace ECom.Services.Reports.Data
{
    public class ReportDbContext : DbContext
    {
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<MonthlyReport> MonthlyReports { get; set; }
        public DbSet<YearlyReport> YearlyReports { get; set; }

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
            
        }
    } 
}
