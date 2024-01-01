using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecom.Services.Forecast.Migrations
{
    /// <inheritdoc />
    public partial class InitForecastDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_updated = table.Column<DateOnly>(type: "Date", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ForecastDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateOnly>(type: "Date", nullable: false),
                    total_sold = table.Column<int>(type: "int", nullable: false),
                    forecast_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_ForecastDetails_Forecasts_forecast_id",
                        column: x => x.forecast_id,
                        principalTable: "Forecasts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "id", "last_updated", "product_id" },
                values: new object[] { 1, new DateOnly(2023, 12, 23), 1 });

            migrationBuilder.InsertData(
                table: "ForecastDetails",
                columns: new[] { "id", "forecast_id", "total_sold", "date" },
                values: new object[,]
                {
                    { 1, 1, 50, new DateOnly(2023, 12, 24) },
                    { 2, 1, 50, new DateOnly(2023, 12, 25) },
                    { 3, 1, 50, new DateOnly(2023, 12, 26) },
                    { 4, 1, 50, new DateOnly(2023, 12, 27) },
                    { 5, 1, 50, new DateOnly(2023, 12, 28) },
                    { 6, 1, 50, new DateOnly(2023, 12, 29) },
                    { 7, 1, 50, new DateOnly(2023, 12, 30) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForecastDetails_forecast_id",
                table: "ForecastDetails",
                column: "forecast_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForecastDetails");

            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}
