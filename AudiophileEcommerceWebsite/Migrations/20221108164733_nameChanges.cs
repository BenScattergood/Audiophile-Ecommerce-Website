using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudiophileEcommerceWebsite.Migrations
{
    public partial class nameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShoppingBasketItems",
                newName: "ShoppingBasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingBasketId",
                table: "ShoppingBasketItems",
                newName: "ShoppingCartId");
        }
    }
}
