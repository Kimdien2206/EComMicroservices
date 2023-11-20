using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Services.Auth.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    logged_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.phone_number);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_email",
                        column: x => x.email,
                        principalTable: "Accounts",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "email", "is_admin", "password" },
                values: new object[,]
                {
                    { "20520442@gmail.com", true, "123456" },
                    { "20520453@gmail.com", false, "123456" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "phone_number", "address", "avatar", "email", "firstname", "lastname", "logged_date" },
                values: new object[,]
                {
                    { "0703391661", "Ba Đình, TP. HCM", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/avatar/default.png", "20520442@gmail.com", "Điền", "Trương Kim", new DateTime(2023, 11, 19, 12, 53, 16, 408, DateTimeKind.Local).AddTicks(7248) },
                    { "0944124232", "Kiến Tường, Long An", "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/avatar/default.png", "20520453@gmail.com", "Đức", "Nguyễn Trí", new DateTime(2023, 11, 19, 12, 53, 16, 408, DateTimeKind.Local).AddTicks(7262) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
