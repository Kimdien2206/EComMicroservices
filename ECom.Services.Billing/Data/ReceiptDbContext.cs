using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECom.Services.Billing.Models;

namespace ECom.Services.Billing.Data
{
    public class ReceiptDbContext : DbContext
    {
        public DbSet<Receipt> Receipts { get; set; }

        public ReceiptDbContext()
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>().HasData(
                new Receipt
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Cost = 500000,
                    Status = '0',
                    VoucherCode = "ABCDEF",
                    OrderId = 1,
                    PaymentMethod = "cod"
                },
                new Receipt
                {
                    Id = 2,
                    Date = DateTime.Now,
                    Cost = 500000,
                    Status = '1',
                    VoucherCode = "ABCDEF",
                    OrderId = 2,
                    PaymentMethod = "cod"
                });
        }
    } 
}
