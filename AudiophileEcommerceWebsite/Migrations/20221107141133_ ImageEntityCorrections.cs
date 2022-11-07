using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudiophileEcommerceWebsite.Migrations
{
    public partial class ImageEntityCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryFirstImage");

            migrationBuilder.DropTable(
                name: "GallerySecondImage");

            migrationBuilder.DropTable(
                name: "GalleryThirdImage");

            migrationBuilder.DropTable(
                name: "ImageRelatedData");

            migrationBuilder.AddColumn<int>(
                name: "ImagesId",
                table: "RelatedData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstId",
                table: "Gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondId",
                table: "Gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThirdId",
                table: "Gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RelatedData_ImagesId",
                table: "RelatedData",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_FirstId",
                table: "Gallery",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_SecondId",
                table: "Gallery",
                column: "SecondId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_ThirdId",
                table: "Gallery",
                column: "ThirdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Image_FirstId",
                table: "Gallery",
                column: "FirstId",
                principalTable: "Image",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Image_SecondId",
                table: "Gallery",
                column: "SecondId",
                principalTable: "Image",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Image_ThirdId",
                table: "Gallery",
                column: "ThirdId",
                principalTable: "Image",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedData_Image_ImagesId",
                table: "RelatedData",
                column: "ImagesId",
                principalTable: "Image",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Image_FirstId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Image_SecondId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Image_ThirdId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedData_Image_ImagesId",
                table: "RelatedData");

            migrationBuilder.DropIndex(
                name: "IX_RelatedData_ImagesId",
                table: "RelatedData");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_FirstId",
                table: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_SecondId",
                table: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_ThirdId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "ImagesId",
                table: "RelatedData");

            migrationBuilder.DropColumn(
                name: "FirstId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "SecondId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "ThirdId",
                table: "Gallery");

            migrationBuilder.CreateTable(
                name: "GalleryFirstImage",
                columns: table => new
                {
                    FirstGalleriesGalleryId = table.Column<int>(type: "int", nullable: false),
                    FirstImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryFirstImage", x => new { x.FirstGalleriesGalleryId, x.FirstImageId });
                    table.ForeignKey(
                        name: "FK_GalleryFirstImage_Gallery_FirstGalleriesGalleryId",
                        column: x => x.FirstGalleriesGalleryId,
                        principalTable: "Gallery",
                        principalColumn: "GalleryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryFirstImage_Image_FirstImageId",
                        column: x => x.FirstImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GallerySecondImage",
                columns: table => new
                {
                    SecondGalleriesGalleryId = table.Column<int>(type: "int", nullable: false),
                    SecondImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GallerySecondImage", x => new { x.SecondGalleriesGalleryId, x.SecondImageId });
                    table.ForeignKey(
                        name: "FK_GallerySecondImage_Gallery_SecondGalleriesGalleryId",
                        column: x => x.SecondGalleriesGalleryId,
                        principalTable: "Gallery",
                        principalColumn: "GalleryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GallerySecondImage_Image_SecondImageId",
                        column: x => x.SecondImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GalleryThirdImage",
                columns: table => new
                {
                    ThirdGalleriesGalleryId = table.Column<int>(type: "int", nullable: false),
                    ThirdImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryThirdImage", x => new { x.ThirdGalleriesGalleryId, x.ThirdImageId });
                    table.ForeignKey(
                        name: "FK_GalleryThirdImage_Gallery_ThirdGalleriesGalleryId",
                        column: x => x.ThirdGalleriesGalleryId,
                        principalTable: "Gallery",
                        principalColumn: "GalleryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryThirdImage_Image_ThirdImageId",
                        column: x => x.ThirdImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageRelatedData",
                columns: table => new
                {
                    ImagesImageId = table.Column<int>(type: "int", nullable: false),
                    RelatedDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageRelatedData", x => new { x.ImagesImageId, x.RelatedDataId });
                    table.ForeignKey(
                        name: "FK_ImageRelatedData_Image_ImagesImageId",
                        column: x => x.ImagesImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageRelatedData_RelatedData_RelatedDataId",
                        column: x => x.RelatedDataId,
                        principalTable: "RelatedData",
                        principalColumn: "RelatedDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryFirstImage_FirstImageId",
                table: "GalleryFirstImage",
                column: "FirstImageId");

            migrationBuilder.CreateIndex(
                name: "IX_GallerySecondImage_SecondImageId",
                table: "GallerySecondImage",
                column: "SecondImageId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryThirdImage_ThirdImageId",
                table: "GalleryThirdImage",
                column: "ThirdImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageRelatedData_RelatedDataId",
                table: "ImageRelatedData",
                column: "RelatedDataId");
        }
    }
}
