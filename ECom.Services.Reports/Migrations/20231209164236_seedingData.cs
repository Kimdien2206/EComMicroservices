using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Services.Reports.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyReports_MonthlyReports_MonthNavigationMonth",
                table: "DailyReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyReports_YearlyReports_YearNavigationYear",
                table: "MonthlyReports");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyReports_YearNavigationYear",
                table: "MonthlyReports");

            migrationBuilder.DropIndex(
                name: "IX_DailyReports_MonthNavigationMonth",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "YearNavigationYear",
                table: "MonthlyReports");

            migrationBuilder.DropColumn(
                name: "MonthNavigationMonth",
                table: "DailyReports");

            migrationBuilder.AlterColumn<long>(
                name: "sold_quantity",
                table: "YearlyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "profit",
                table: "YearlyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "outcome",
                table: "YearlyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "income",
                table: "YearlyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "profit",
                table: "MonthlyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "outcome",
                table: "MonthlyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "income",
                table: "MonthlyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateOnly>(
                name: "YearlyReportYear",
                table: "MonthlyReports",
                type: "Date",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "profit",
                table: "DailyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "outcome",
                table: "DailyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "income",
                table: "DailyReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateOnly>(
                name: "MonthlyReportMonth",
                table: "DailyReports",
                type: "Date",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DailyReports",
                columns: new[] { "date", "income", "month", "MonthlyReportMonth", "outcome", "profit", "sold_quantity" },
                values: new object[,]
                {
                    { new DateOnly(2023, 12, 1), 500000L, new DateOnly(2023, 12, 1), null, 80000L, 400830L, 5 },
                    { new DateOnly(2023, 12, 2), 5520100L, new DateOnly(2023, 12, 1), null, 400800L, 4328830L, 50 },
                    { new DateOnly(2023, 12, 3), 2014000L, new DateOnly(2023, 12, 1), null, 442500L, 1524830L, 20 },
                    { new DateOnly(2023, 12, 4), 2140000L, new DateOnly(2023, 12, 1), null, 210800L, 1258830L, 500 },
                    { new DateOnly(2023, 12, 5), 32500000L, new DateOnly(2023, 12, 1), null, 4000800L, 36228830L, 500 },
                    { new DateOnly(2023, 12, 6), 9600000L, new DateOnly(2023, 12, 1), null, 520800L, 9218830L, 500 },
                    { new DateOnly(2023, 12, 7), 12025200L, new DateOnly(2023, 12, 1), null, 4042800L, 8518830L, 500 },
                    { new DateOnly(2023, 12, 8), 54740000L, new DateOnly(2023, 12, 1), null, 41200L, 2418830L, 500 },
                    { new DateOnly(2023, 12, 9), 12400000L, new DateOnly(2023, 12, 1), null, 440800L, 1423830L, 500 },
                    { new DateOnly(2023, 12, 10), 14250000L, new DateOnly(2023, 12, 1), null, 456486L, 8451246L, 500 },
                    { new DateOnly(2023, 12, 11), 4675652L, new DateOnly(2023, 12, 1), null, 656264L, 6542642L, 500 },
                    { new DateOnly(2023, 12, 12), 64865224L, new DateOnly(2023, 12, 1), null, 864564L, 65634266L, 500 },
                    { new DateOnly(2023, 12, 13), 4263164L, new DateOnly(2023, 12, 1), null, 6542164L, 6464568L, 500 },
                    { new DateOnly(2023, 12, 14), 456462161L, new DateOnly(2023, 12, 1), null, 756576L, 56746264L, 500 },
                    { new DateOnly(2023, 12, 15), 45642621L, new DateOnly(2023, 12, 1), null, 5648646L, 546465L, 500 },
                    { new DateOnly(2023, 12, 16), 54642562L, new DateOnly(2023, 12, 1), null, 4566456L, 54648626L, 500 },
                    { new DateOnly(2023, 12, 17), 56426321L, new DateOnly(2023, 12, 1), null, 564568L, 26456876L, 500 },
                    { new DateOnly(2023, 12, 18), 45621654L, new DateOnly(2023, 12, 1), null, 456878L, 5464562L, 500 },
                    { new DateOnly(2023, 12, 19), 126126568L, new DateOnly(2023, 12, 1), null, 5462161L, 7865612L, 500 },
                    { new DateOnly(2023, 12, 20), 4562166L, new DateOnly(2023, 12, 1), null, 45642L, 4564566L, 500 },
                    { new DateOnly(2023, 12, 21), 4564876L, new DateOnly(2023, 12, 1), null, 126456L, 2134566L, 500 },
                    { new DateOnly(2023, 12, 22), 56766754L, new DateOnly(2023, 12, 1), null, 937388L, 35835677L, 500 },
                    { new DateOnly(2023, 12, 23), 35675476L, new DateOnly(2023, 12, 1), null, 465849L, 763457L, 500 },
                    { new DateOnly(2023, 12, 24), 4363464L, new DateOnly(2023, 12, 1), null, 400800L, 4328830L, 500 },
                    { new DateOnly(2023, 12, 25), 2342351L, new DateOnly(2023, 12, 1), null, 542554L, 2312424L, 500 },
                    { new DateOnly(2023, 12, 26), 23523566L, new DateOnly(2023, 12, 1), null, 234241L, 5474724L, 500 },
                    { new DateOnly(2023, 12, 27), 24754645L, new DateOnly(2023, 12, 1), null, 2525563L, 3135153L, 500 },
                    { new DateOnly(2023, 12, 28), 23564436L, new DateOnly(2023, 12, 1), null, 2352546L, 4564754L, 500 },
                    { new DateOnly(2023, 12, 29), 3463467L, new DateOnly(2023, 12, 1), null, 3457378L, 3453253L, 500 },
                    { new DateOnly(2023, 12, 30), 2365464L, new DateOnly(2023, 12, 1), null, 3464685L, 3452352L, 500 }
                });

            migrationBuilder.InsertData(
                table: "MonthlyReports",
                columns: new[] { "month", "income", "outcome", "profit", "sold_quantity", "year", "YearlyReportYear" },
                values: new object[,]
                {
                    { new DateOnly(2023, 1, 1), 50000000L, 4000800L, 4328830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 2, 1), 4200000L, 40800L, 432830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 3, 1), 55808000L, 4000800L, 4328830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 4, 1), 5080000L, 4005800L, 43258830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 5, 1), 23000000L, 5140800L, 3288306L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 6, 1), 542540000L, 4133500L, 4328830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 7, 1), 41360000L, 7530800L, 4328830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 8, 1), 1430000L, 300800L, 3228830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 9, 1), 32320000L, 400800L, 4322830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 10, 1), 223300000L, 53658800L, 46568830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 11, 1), 50000000L, 4000800L, 4328830L, 500, new DateOnly(2023, 1, 1), null },
                    { new DateOnly(2023, 12, 1), 50000000L, 4000800L, 4328830L, 500, new DateOnly(2023, 1, 1), null }
                });

            migrationBuilder.InsertData(
                table: "YearlyReports",
                columns: new[] { "year", "income", "outcome", "profit", "sold_quantity" },
                values: new object[] { new DateOnly(2023, 1, 1), 5000000000L, 490000800L, 4903928830L, 50000L });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyReports_YearlyReportYear",
                table: "MonthlyReports",
                column: "YearlyReportYear");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_MonthlyReportMonth",
                table: "DailyReports",
                column: "MonthlyReportMonth");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReports_MonthlyReports_MonthlyReportMonth",
                table: "DailyReports",
                column: "MonthlyReportMonth",
                principalTable: "MonthlyReports",
                principalColumn: "month");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyReports_YearlyReports_YearlyReportYear",
                table: "MonthlyReports",
                column: "YearlyReportYear",
                principalTable: "YearlyReports",
                principalColumn: "year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyReports_MonthlyReports_MonthlyReportMonth",
                table: "DailyReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyReports_YearlyReports_YearlyReportYear",
                table: "MonthlyReports");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyReports_YearlyReportYear",
                table: "MonthlyReports");

            migrationBuilder.DropIndex(
                name: "IX_DailyReports_MonthlyReportMonth",
                table: "DailyReports");

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 1));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 2));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 3));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 4));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 5));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 6));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 7));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 8));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 9));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 10));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 11));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 12));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 13));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 14));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 15));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 16));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 17));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 18));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 19));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 20));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 21));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 22));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 23));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 24));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 25));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 26));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 27));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 28));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 29));

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "date",
                keyValue: new DateOnly(2023, 12, 30));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 1, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 2, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 3, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 4, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 5, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 6, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 7, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 8, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 9, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 10, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 11, 1));

            migrationBuilder.DeleteData(
                table: "MonthlyReports",
                keyColumn: "month",
                keyValue: new DateOnly(2023, 12, 1));

            migrationBuilder.DeleteData(
                table: "YearlyReports",
                keyColumn: "year",
                keyValue: new DateOnly(2023, 1, 1));

            migrationBuilder.DropColumn(
                name: "YearlyReportYear",
                table: "MonthlyReports");

            migrationBuilder.DropColumn(
                name: "MonthlyReportMonth",
                table: "DailyReports");

            migrationBuilder.AlterColumn<int>(
                name: "sold_quantity",
                table: "YearlyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "profit",
                table: "YearlyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "outcome",
                table: "YearlyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "income",
                table: "YearlyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "profit",
                table: "MonthlyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "outcome",
                table: "MonthlyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "income",
                table: "MonthlyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateOnly>(
                name: "YearNavigationYear",
                table: "MonthlyReports",
                type: "Date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<int>(
                name: "profit",
                table: "DailyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "outcome",
                table: "DailyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "income",
                table: "DailyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateOnly>(
                name: "MonthNavigationMonth",
                table: "DailyReports",
                type: "Date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyReports_YearNavigationYear",
                table: "MonthlyReports",
                column: "YearNavigationYear");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_MonthNavigationMonth",
                table: "DailyReports",
                column: "MonthNavigationMonth");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReports_MonthlyReports_MonthNavigationMonth",
                table: "DailyReports",
                column: "MonthNavigationMonth",
                principalTable: "MonthlyReports",
                principalColumn: "month",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyReports_YearlyReports_YearNavigationYear",
                table: "MonthlyReports",
                column: "YearNavigationYear",
                principalTable: "YearlyReports",
                principalColumn: "year",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
