using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Services.Billing.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
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
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "cost", "date", "order_id", "payment_method", "status", "voucher_code" },
                values: new object[,]
                {
                    { 1, 500000, new DateTime(2023, 12, 8, 13, 29, 1, 311, DateTimeKind.Local).AddTicks(6069), 1, "cod", "0", "ABCDEF" },
                    { 2, 500000, new DateTime(2023, 12, 8, 13, 29, 1, 311, DateTimeKind.Local).AddTicks(6085), 2, "cod", "1", "ABCDEF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
