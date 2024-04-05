using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudiophileEcommerceWebsite.Migrations
{
    public partial class UpdateUserIdOnOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DECLARE @userId as nvarchar(450) = null;

SELECT Top 1 @userId = (Id)
  FROM .[dbo].[AspNetUsers]

  UPDATE dbo.[Orders] SET UserId = (@userId)
  FROM	dbo.[Orders]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
