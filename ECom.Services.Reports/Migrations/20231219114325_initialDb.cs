using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    income = table.Column<long>(type: "bigint", nullable: false),
                    outcome = table.Column<long>(type: "bigint", nullable: false),
                    profit = table.Column<long>(type: "bigint", nullable: false),
                    sold_quantity = table.Column<long>(type: "bigint", nullable: false)
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
                    income = table.Column<long>(type: "bigint", nullable: false),
                    outcome = table.Column<long>(type: "bigint", nullable: false),
                    profit = table.Column<long>(type: "bigint", nullable: false),
                    sold_quantity = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<DateOnly>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyReports", x => x.month);
                    table.ForeignKey(
                        name: "FK_MonthlyReports_YearlyReports_year",
                        column: x => x.year,
                        principalTable: "YearlyReports",
                        principalColumn: "year",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyReports",
                columns: table => new
                {
                    date = table.Column<DateOnly>(type: "Date", nullable: false),
                    income = table.Column<long>(type: "bigint", nullable: false),
                    outcome = table.Column<long>(type: "bigint", nullable: false),
                    profit = table.Column<long>(type: "bigint", nullable: false),
                    sold_quantity = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<DateOnly>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReports", x => x.date);
                    table.ForeignKey(
                        name: "FK_DailyReports_MonthlyReports_month",
                        column: x => x.month,
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
                    date = table.Column<DateOnly>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_DailyReportDetail_DailyReports_date",
                        column: x => x.date,
                        principalTable: "DailyReports",
                        principalColumn: "date",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "YearlyReports",
                columns: new[] { "year", "income", "outcome", "profit", "sold_quantity" },
                values: new object[] { new DateOnly(2023, 1, 1), 5000000000L, 490000800L, 4903928830L, 50000L });

            migrationBuilder.InsertData(
                table: "MonthlyReports",
                columns: new[] { "month", "income", "outcome", "profit", "sold_quantity", "year" },
                values: new object[,]
                {
                    { new DateOnly(2023, 1, 1), 50000000L, 4000800L, 4328830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 2, 1), 4200000L, 40800L, 432830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 3, 1), 55808000L, 4000800L, 4328830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 4, 1), 5080000L, 4005800L, 43258830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 5, 1), 23000000L, 5140800L, 3288306L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 6, 1), 542540000L, 4133500L, 4328830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 7, 1), 41360000L, 7530800L, 4328830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 8, 1), 1430000L, 300800L, 3228830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 9, 1), 32320000L, 400800L, 4322830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 10, 1), 223300000L, 53658800L, 46568830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 11, 1), 50000000L, 4000800L, 4328830L, 500, new DateOnly(2023, 1, 1) },
                    { new DateOnly(2023, 12, 1), 50000000L, 4000800L, 4328830L, 500, new DateOnly(2023, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "DailyReports",
                columns: new[] { "date", "income", "month", "outcome", "profit", "sold_quantity" },
                values: new object[,]
                {
                    { new DateOnly(2023, 12, 1), 500000L, new DateOnly(2023, 12, 1), 80000L, 400830L, 5 },
                    { new DateOnly(2023, 12, 2), 5520100L, new DateOnly(2023, 12, 1), 400800L, 4328830L, 50 },
                    { new DateOnly(2023, 12, 3), 2014000L, new DateOnly(2023, 12, 1), 442500L, 1524830L, 20 },
                    { new DateOnly(2023, 12, 4), 2140000L, new DateOnly(2023, 12, 1), 210800L, 1258830L, 500 },
                    { new DateOnly(2023, 12, 5), 32500000L, new DateOnly(2023, 12, 1), 4000800L, 36228830L, 500 },
                    { new DateOnly(2023, 12, 6), 9600000L, new DateOnly(2023, 12, 1), 520800L, 9218830L, 500 },
                    { new DateOnly(2023, 12, 7), 12025200L, new DateOnly(2023, 12, 1), 4042800L, 8518830L, 500 },
                    { new DateOnly(2023, 12, 8), 54740000L, new DateOnly(2023, 12, 1), 41200L, 2418830L, 500 },
                    { new DateOnly(2023, 12, 9), 12400000L, new DateOnly(2023, 12, 1), 440800L, 1423830L, 500 },
                    { new DateOnly(2023, 12, 10), 14250000L, new DateOnly(2023, 12, 1), 456486L, 8451246L, 500 },
                    { new DateOnly(2023, 12, 11), 4675652L, new DateOnly(2023, 12, 1), 656264L, 6542642L, 500 },
                    { new DateOnly(2023, 12, 12), 64865224L, new DateOnly(2023, 12, 1), 864564L, 65634266L, 500 },
                    { new DateOnly(2023, 12, 13), 4263164L, new DateOnly(2023, 12, 1), 6542164L, 6464568L, 500 },
                    { new DateOnly(2023, 12, 14), 456462161L, new DateOnly(2023, 12, 1), 756576L, 56746264L, 500 },
                    { new DateOnly(2023, 12, 15), 45642621L, new DateOnly(2023, 12, 1), 5648646L, 546465L, 500 },
                    { new DateOnly(2023, 12, 16), 54642562L, new DateOnly(2023, 12, 1), 4566456L, 54648626L, 500 },
                    { new DateOnly(2023, 12, 17), 56426321L, new DateOnly(2023, 12, 1), 564568L, 26456876L, 500 },
                    { new DateOnly(2023, 12, 18), 45621654L, new DateOnly(2023, 12, 1), 456878L, 5464562L, 500 },
                    { new DateOnly(2023, 12, 19), 126126568L, new DateOnly(2023, 12, 1), 5462161L, 7865612L, 500 },
                    { new DateOnly(2023, 12, 20), 4562166L, new DateOnly(2023, 12, 1), 45642L, 4564566L, 500 },
                    { new DateOnly(2023, 12, 21), 4564876L, new DateOnly(2023, 12, 1), 126456L, 2134566L, 500 },
                    { new DateOnly(2023, 12, 22), 56766754L, new DateOnly(2023, 12, 1), 937388L, 35835677L, 500 },
                    { new DateOnly(2023, 12, 23), 35675476L, new DateOnly(2023, 12, 1), 465849L, 763457L, 500 },
                    { new DateOnly(2023, 12, 24), 4363464L, new DateOnly(2023, 12, 1), 400800L, 4328830L, 500 },
                    { new DateOnly(2023, 12, 25), 2342351L, new DateOnly(2023, 12, 1), 542554L, 2312424L, 500 },
                    { new DateOnly(2023, 12, 26), 23523566L, new DateOnly(2023, 12, 1), 234241L, 5474724L, 500 },
                    { new DateOnly(2023, 12, 27), 24754645L, new DateOnly(2023, 12, 1), 2525563L, 3135153L, 500 },
                    { new DateOnly(2023, 12, 28), 23564436L, new DateOnly(2023, 12, 1), 2352546L, 4564754L, 500 },
                    { new DateOnly(2023, 12, 29), 3463467L, new DateOnly(2023, 12, 1), 3457378L, 3453253L, 500 },
                    { new DateOnly(2023, 12, 30), 2365464L, new DateOnly(2023, 12, 1), 3464685L, 3452352L, 500 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportDetail_date",
                table: "DailyReportDetail",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_month",
                table: "DailyReports",
                column: "month");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyReports_year",
                table: "MonthlyReports",
                column: "year");
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
