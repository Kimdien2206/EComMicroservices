﻿// <auto-generated />
using ECom.Services.Carts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECom.Services.Carts.Migrations
{
    [DbContext(typeof(CartDbContext))]
    partial class CartDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECom.Services.Carts.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone_number");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemId = 1,
                            PhoneNumber = "0703391661",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            ItemId = 14,
                            PhoneNumber = "0703391661",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            ItemId = 3,
                            PhoneNumber = "0703391661",
                            Quantity = 5
                        },
                        new
                        {
                            Id = 4,
                            ItemId = 5,
                            PhoneNumber = "0703391661",
                            Quantity = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
