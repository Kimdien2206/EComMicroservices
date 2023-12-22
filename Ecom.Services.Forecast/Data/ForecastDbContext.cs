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
        }

    }
}
