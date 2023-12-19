using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Services.Billing.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    voucher_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Receipts",
                columns: new[] { "id", "cost", "date", "order_id", "payment_method", "status", "voucher_code" },
                values: new object[,]
                {
                    { 1, 500000, new DateTime(2023, 12, 19, 14, 10, 28, 479, DateTimeKind.Local).AddTicks(4194), 1, "cod", "0", "ABCDEF" },
                    { 2, 500000, new DateTime(2023, 12, 19, 14, 10, 28, 479, DateTimeKind.Local).AddTicks(4207), 2, "cod", "1", "ABCDEF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipts");
        }
    }
}
