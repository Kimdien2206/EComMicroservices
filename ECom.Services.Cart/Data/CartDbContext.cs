using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECom.Services.Cart.Models;

namespace ECom.Services.Cart.Data
{
    public class CartDbContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }

        public CartDbContext()
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
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Cost = 500000,
                    Status = '0',
                    VoucherCode = "ABCDEF",
                    OrderId = 1,
                    PaymentMethod = "cod"
                }
                );
        }
    } 
}
