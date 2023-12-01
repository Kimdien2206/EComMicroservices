using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECom.Services.Sales.Models;

namespace ECom.Services.Sales.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public OrderDbContext()
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
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Date = DateTime.Now,
                    TotalCost = 500000,
                    Status = '0',
                    Address = "Ba Đình, Tp HCM",
                    Firstname = "Kim Điền",
                    Lastname = "Trương",
                    PhoneNumber = "0703391661"
                },
                new Order
                {
                    Id = 2,
                    Date = DateTime.Now,
                    TotalCost = 500000,
                    Status = '1',
                    Address = "Ba Đình, Tp HCM",
                    Firstname = "Kim Điền",
                    Lastname = "Trương",
                    PhoneNumber = "0703391661"
                },
                new Order
                {
                    Id = 3,
                    Date = DateTime.Now,
                    TotalCost = 500000,
                    Status = '2',
                    Address = "Ba Đình, Tp HCM",
                    Firstname = "Kim Điền",
                    Lastname = "Trương",
                    PhoneNumber = "0703391661"
                },
                new Order
                {
                    Id = 4,
                    Date = DateTime.Now,
                    TotalCost = 500000,
                    Status = '3',
                    Address = "Ba Đình, Tp HCM",
                    Firstname = "Kim Điền",
                    Lastname = "Trương",
                    PhoneNumber = "0703391661"
                });
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Id = 1,
                    OrderId = 1,
                    ItemId = 1,
                    Quantity = 1,
                },
                new OrderDetail
                {
                    Id = 2,
                    OrderId = 2,
                    ItemId = 13,
                    Quantity = 1,
                },
                new OrderDetail
                {
                    Id = 3,
                    OrderId = 2,
                    ItemId = 8,
                    Quantity = 1,
                },
                new OrderDetail
                {
                    Id = 4,
                    OrderId = 3,
                    ItemId = 3,
                    Quantity = 1,
                },
                new OrderDetail
                {
                    Id = 5,
                    OrderId = 4,
                    ItemId = 6,
                    Quantity = 1,
                });
        }
    } 
}
