using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class VoegProductIdToeAanBestelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellings_Product_ProductId",
                table: "Bestellings");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Bestellings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellings_Product_ProductId",
                table: "Bestellings",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellings_Product_ProductId",
                table: "Bestellings");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Bestellings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellings_Product_ProductId",
                table: "Bestellings",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
