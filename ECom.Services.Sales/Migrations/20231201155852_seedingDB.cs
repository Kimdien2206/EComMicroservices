using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Services.Sales.Migrations
{
    /// <inheritdoc />
    public partial class seedingDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "address", "date", "firstname", "lastname", "phone_number", "status", "total_cost" },
                values: new object[,]
                {
                    { 1, "Ba Đình, Tp HCM", new DateTime(2023, 12, 1, 22, 58, 51, 916, DateTimeKind.Local).AddTicks(103), "Kim Điền", "Trương", "0703391661", "0", 500000 },
                    { 2, "Ba Đình, Tp HCM", new DateTime(2023, 12, 1, 22, 58, 51, 916, DateTimeKind.Local).AddTicks(118), "Kim Điền", "Trương", "0703391661", "1", 500000 },
                    { 3, "Ba Đình, Tp HCM", new DateTime(2023, 12, 1, 22, 58, 51, 916, DateTimeKind.Local).AddTicks(121), "Kim Điền", "Trương", "0703391661", "2", 500000 },
                    { 4, "Ba Đình, Tp HCM", new DateTime(2023, 12, 1, 22, 58, 51, 916, DateTimeKind.Local).AddTicks(124), "Kim Điền", "Trương", "0703391661", "3", 500000 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "id", "item_id", "order_id", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 13, 2, 1 },
                    { 3, 8, 2, 1 },
                    { 4, 3, 3, 1 },
                    { 5, 6, 4, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
