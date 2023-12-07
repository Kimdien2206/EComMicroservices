using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Services.Sales.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
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
                    total_cost = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "address", "date", "firstname", "lastname", "phone_number", "status", "total_cost" },
                values: new object[,]
                {
                    { 1, "Ba Đình, Tp HCM", new DateTime(2023, 12, 4, 12, 55, 44, 787, DateTimeKind.Local).AddTicks(7353), "Kim Điền", "Trương", "0703391661", "0", 500000 },
                    { 2, "Ba Đình, Tp HCM", new DateTime(2023, 12, 4, 12, 55, 44, 787, DateTimeKind.Local).AddTicks(7365), "Kim Điền", "Trương", "0703391661", "1", 500000 },
                    { 3, "Ba Đình, Tp HCM", new DateTime(2023, 12, 4, 12, 55, 44, 787, DateTimeKind.Local).AddTicks(7367), "Kim Điền", "Trương", "0703391661", "2", 500000 },
                    { 4, "Ba Đình, Tp HCM", new DateTime(2023, 12, 4, 12, 55, 44, 787, DateTimeKind.Local).AddTicks(7369), "Kim Điền", "Trương", "0703391661", "3", 500000 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "id", "item_id", "order_id", "price", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, 1 },
                    { 2, 13, 2, 0, 1 },
                    { 3, 8, 2, 0, 1 },
                    { 4, 3, 3, 0, 1 },
                    { 5, 6, 4, 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_order_id",
                table: "OrderDetails",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
