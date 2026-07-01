using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_Data_Layer.Migrations
{
    /// <inheritdoc />
    public partial class Fix_But_Product_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductGalleries_ParentId",
                table: "ProductCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId",
                principalTable: "ProductCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductGalleries_ParentId",
                table: "ProductCategories",
                column: "ParentId",
                principalTable: "ProductGalleries",
                principalColumn: "Id");
        }
    }
}
