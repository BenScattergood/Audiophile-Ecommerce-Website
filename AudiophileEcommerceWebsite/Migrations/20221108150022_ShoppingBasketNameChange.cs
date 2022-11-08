using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudiophileEcommerceWebsite.Migrations
{
    public partial class ShoppingBasketNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ShoppingBasketItems",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ShoppingBasketItems",
                newName: "Amount");
        }
    }
}
