using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Services.Products.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tags_discount_id",
                table: "Tags",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_product_id",
                table: "Reviews",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_collection_id",
                table: "Products",
                column: "collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_discount_id",
                table: "Products",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_product_id",
                table: "ProductItems",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_HasTags_product_id",
                table: "HasTags",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_HasTags_tag_id",
                table: "HasTags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_discount_id",
                table: "Collections",
                column: "discount_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Discounts_discount_id",
                table: "Collections",
                column: "discount_id",
                principalTable: "Discounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_HasTags_Products_product_id",
                table: "HasTags",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasTags_Tags_tag_id",
                table: "HasTags",
                column: "tag_id",
                principalTable: "Tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Products_product_id",
                table: "ProductItems",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Collections_collection_id",
                table: "Products",
                column: "collection_id",
                principalTable: "Collections",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_discount_id",
                table: "Products",
                column: "discount_id",
                principalTable: "Discounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_product_id",
                table: "Reviews",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Discounts_discount_id",
                table: "Tags",
                column: "discount_id",
                principalTable: "Discounts",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Discounts_discount_id",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_HasTags_Products_product_id",
                table: "HasTags");

            migrationBuilder.DropForeignKey(
                name: "FK_HasTags_Tags_tag_id",
                table: "HasTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Products_product_id",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Collections_collection_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_discount_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_product_id",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Discounts_discount_id",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_discount_id",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_product_id",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Products_collection_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_discount_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_product_id",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_HasTags_product_id",
                table: "HasTags");

            migrationBuilder.DropIndex(
                name: "IX_HasTags_tag_id",
                table: "HasTags");

            migrationBuilder.DropIndex(
                name: "IX_Collections_discount_id",
                table: "Collections");
        }
    }
}
