using Ecom.Services.Forecasts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECom.Services.Forecasts.Data
{
    public class ForecastDbContext : DbContext
    {
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<ForecastDetail> ForecastDetails { get; set; }
        
        public ForecastDbContext()
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
            modelBuilder.Entity<Forecast>().HasData(new Forecast() { Id = 1, LastUpdated = DateOnly.FromDateTime(DateTime.Now), ProductId = 1 });

            modelBuilder.Entity<ForecastDetail>().HasData(
                new ForecastDetail() { Id = 1, date = DateOnly.FromDateTime(DateTime.Now).AddDays(1), ForecastId = 1, TotalSold = 50 },
                new ForecastDetail() { Id = 2, date = DateOnly.FromDateTime(DateTime.Now).AddDays(2), ForecastId = 1, TotalSold = 50 },
                new ForecastDetail() { Id = 3, date = DateOnly.FromDateTime(DateTime.Now).AddDays(3), ForecastId = 1, TotalSold = 50 },
                new ForecastDetail() { Id = 4, date = DateOnly.FromDateTime(DateTime.Now).AddDays(4), ForecastId = 1, TotalSold = 50 },
                new ForecastDetail() { Id = 5, date = DateOnly.FromDateTime(DateTime.Now).AddDays(5), ForecastId = 1, TotalSold = 50 },
                new ForecastDetail() { Id = 6, date = DateOnly.FromDateTime(DateTime.Now).AddDays(6), ForecastId = 1, TotalSold = 50 },
                new ForecastDetail() { Id = 7, date = DateOnly.FromDateTime(DateTime.Now).AddDays(7), ForecastId = 1, TotalSold = 50 }
            );
        }

    }
}
