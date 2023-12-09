using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Services.Reports.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YearlyReports",
                columns: table => new
                {
                    year = table.Column<DateOnly>(type: "Date", nullable: false),
                    income = table.Column<int>(type: "int", nullable: false),
                    outcome = table.Column<int>(type: "int", nullable: false),
                    profit = table.Column<int>(type: "int", nullable: false),
                    sold_quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlyReports", x => x.year);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyReports",
                columns: table => new
                {
                    month = table.Column<DateOnly>(type: "Date", nullable: false),
                    income = table.Column<int>(type: "int", nullable: false),
                    outcome = table.Column<int>(type: "int", nullable: false),
                    profit = table.Column<int>(type: "int", nullable: false),
                    sold_quantity = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<DateOnly>(type: "Date", nullable: false),
                    YearNavigationYear = table.Column<DateOnly>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyReports", x => x.month);
                    table.ForeignKey(
                        name: "FK_MonthlyReports_YearlyReports_YearNavigationYear",
                        column: x => x.YearNavigationYear,
                        principalTable: "YearlyReports",
                        principalColumn: "year",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyReports",
                columns: table => new
                {
                    date = table.Column<DateOnly>(type: "Date", nullable: false),
                    income = table.Column<int>(type: "int", nullable: false),
                    outcome = table.Column<int>(type: "int", nullable: false),
                    profit = table.Column<int>(type: "int", nullable: false),
                    sold_quantity = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<DateOnly>(type: "Date", nullable: false),
                    MonthNavigationMonth = table.Column<DateOnly>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReports", x => x.date);
                    table.ForeignKey(
                        name: "FK_DailyReports_MonthlyReports_MonthNavigationMonth",
                        column: x => x.MonthNavigationMonth,
                        principalTable: "MonthlyReports",
                        principalColumn: "month",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "Date", nullable: false),
                    DateNavigationDate = table.Column<DateOnly>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_DailyReportDetail_DailyReports_DateNavigationDate",
                        column: x => x.DateNavigationDate,
                        principalTable: "DailyReports",
                        principalColumn: "date",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportDetail_DateNavigationDate",
                table: "DailyReportDetail",
                column: "DateNavigationDate");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_MonthNavigationMonth",
                table: "DailyReports",
                column: "MonthNavigationMonth");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyReports_YearNavigationYear",
                table: "MonthlyReports",
                column: "YearNavigationYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReportDetail");

            migrationBuilder.DropTable(
                name: "DailyReports");

            migrationBuilder.DropTable(
                name: "MonthlyReports");

            migrationBuilder.DropTable(
                name: "YearlyReports");
        }
    }
}
