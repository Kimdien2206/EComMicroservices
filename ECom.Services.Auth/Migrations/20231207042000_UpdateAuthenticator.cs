using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Services.Auth.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuthenticator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Authenticators",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authenticators",
                table: "Authenticators",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "phone_number",
                keyValue: "0703391661",
                column: "logged_date",
                value: new DateTime(2023, 12, 7, 11, 19, 59, 913, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "phone_number",
                keyValue: "0944124232",
                column: "logged_date",
                value: new DateTime(2023, 12, 7, 11, 19, 59, 913, DateTimeKind.Local).AddTicks(1123));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Authenticators",
                table: "Authenticators");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Authenticators");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "phone_number",
                keyValue: "0703391661",
                column: "logged_date",
                value: new DateTime(2023, 12, 7, 9, 5, 55, 728, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "phone_number",
                keyValue: "0944124232",
                column: "logged_date",
                value: new DateTime(2023, 12, 7, 9, 5, 55, 728, DateTimeKind.Local).AddTicks(6466));
        }
    }
}
