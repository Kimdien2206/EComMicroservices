using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Services.Auth.Models;
using Microsoft.Extensions.Configuration;

namespace ECom.Services.Auth.Data
{
    public class AuthDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Authenticator> Authenticators { get; set; }


        public AuthDbContext()
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
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    PhoneNumber = "0703391661",
                    Firstname = "Điền",
                    Lastname = "Trương Kim",
                    Address = "Ba Đình, TP. HCM",
                    Avatar = "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/avatar/default.png",
                    Email = "20520442@gmail.com",
                    LoggedDate = DateTime.Now
                },
                new User
                {
                    PhoneNumber = "0944124232",
                    Firstname = "Đức",
                    Lastname = "Nguyễn Trí",
                    Address = "Kiến Tường, Long An",
                    Avatar = "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/avatar/default.png",
                    Email = "nguyenduc147862@gmail.com",
                    LoggedDate = DateTime.Now
                }
                );
            modelBuilder.Entity<Account>().HasData(
                new Account { Email = "20520442@gmail.com", Password = "123456", IsAdmin = true },
                new Account { Email = "nguyenduc147862@gmail.com", Password = "123456", IsAdmin = false }
                );
        }
    } 
}
