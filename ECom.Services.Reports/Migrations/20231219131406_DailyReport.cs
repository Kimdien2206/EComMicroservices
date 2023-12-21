using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Services.Reports.Migrations
{
    /// <inheritdoc />
    public partial class DailyReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyReportDetail_DailyReports_date",
                table: "DailyReportDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyReportDetail",
                table: "DailyReportDetail");

            migrationBuilder.RenameTable(
                name: "DailyReportDetail",
                newName: "DailyReportDetails");

            migrationBuilder.RenameIndex(
                name: "IX_DailyReportDetail_date",
                table: "DailyReportDetails",
                newName: "IX_DailyReportDetails_date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyReportDetails",
                table: "DailyReportDetails",
                column: "id");

            migrationBuilder.InsertData(
                table: "DailyReportDetails",
                columns: new[] { "id", "date", "product_id", "quantity" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 12, 1), 1, 18 },
                    { 2, new DateOnly(2023, 12, 2), 1, 5 },
                    { 3, new DateOnly(2023, 12, 3), 1, 16 },
                    { 4, new DateOnly(2023, 12, 4), 1, 3 },
                    { 5, new DateOnly(2023, 12, 5), 1, 17 },
                    { 6, new DateOnly(2023, 12, 6), 1, 5 },
                    { 7, new DateOnly(2023, 12, 7), 1, 4 },
                    { 8, new DateOnly(2023, 12, 8), 1, 7 },
                    { 9, new DateOnly(2023, 12, 9), 1, 17 },
                    { 10, new DateOnly(2023, 12, 10), 1, 7 },
                    { 11, new DateOnly(2023, 12, 11), 1, 15 },
                    { 12, new DateOnly(2023, 12, 12), 1, 18 },
                    { 13, new DateOnly(2023, 12, 13), 1, 7 },
                    { 14, new DateOnly(2023, 12, 14), 1, 17 },
                    { 15, new DateOnly(2023, 12, 15), 1, 11 },
                    { 16, new DateOnly(2023, 12, 16), 1, 12 },
                    { 17, new DateOnly(2023, 12, 17), 1, 11 },
                    { 18, new DateOnly(2023, 12, 18), 1, 9 },
                    { 19, new DateOnly(2023, 12, 19), 1, 5 },
                    { 20, new DateOnly(2023, 12, 20), 1, 5 },
                    { 21, new DateOnly(2023, 12, 21), 1, 8 },
                    { 22, new DateOnly(2023, 12, 22), 1, 8 },
                    { 23, new DateOnly(2023, 12, 23), 1, 7 },
                    { 24, new DateOnly(2023, 12, 24), 1, 5 },
                    { 25, new DateOnly(2023, 12, 25), 1, 10 },
                    { 26, new DateOnly(2023, 12, 26), 1, 8 },
                    { 27, new DateOnly(2023, 12, 27), 1, 13 },
                    { 28, new DateOnly(2023, 12, 28), 1, 1 },
                    { 29, new DateOnly(2023, 12, 29), 1, 18 },
                    { 30, new DateOnly(2023, 12, 30), 1, 8 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReportDetails_DailyReports_date",
                table: "DailyReportDetails",
                column: "date",
                principalTable: "DailyReports",
                principalColumn: "date",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyReportDetails_DailyReports_date",
                table: "DailyReportDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyReportDetails",
                table: "DailyReportDetails");

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DailyReportDetails",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.RenameTable(
                name: "DailyReportDetails",
                newName: "DailyReportDetail");

            migrationBuilder.RenameIndex(
                name: "IX_DailyReportDetails_date",
                table: "DailyReportDetail",
                newName: "IX_DailyReportDetail_date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyReportDetail",
                table: "DailyReportDetail",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReportDetail_DailyReports_date",
                table: "DailyReportDetail",
                column: "date",
                principalTable: "DailyReports",
                principalColumn: "date",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
