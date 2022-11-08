using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudiophileEcommerceWebsite.Migrations
{
    public partial class AddShoppingBasketItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingBasketItems",
                columns: table => new
                {
                    ShoppingBasketItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBasketItems", x => x.ShoppingBasketItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingBasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasketItems_ProductId",
                table: "ShoppingBasketItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingBasketItems");
        }
    }
}
