using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECom.Services.Carts.Models;

namespace ECom.Services.Carts.Data
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
                    ItemId = 1,
                    Quantity = 1,
                    PhoneNumber = "0703391661"
                },
                new Cart
                {
                    Id = 2,
                    ItemId = 14,
                    Quantity = 1,
                    PhoneNumber = "0703391661"
                },
                new Cart
                {
                    Id = 3,
                    ItemId = 3,
                    Quantity = 5,
                    PhoneNumber = "0703391661"
                },
                new Cart
                {
                    Id = 4,
                    ItemId = 5,
                    Quantity = 2,
                    PhoneNumber = "0703391661"
                }
                );
        }
    } 
}
