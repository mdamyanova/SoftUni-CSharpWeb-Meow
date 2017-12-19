namespace Meow.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddImagesToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "HomeCats");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AdoptionCats");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "HomeCats",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "AdoptionCats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "HomeCats");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AdoptionCats");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "HomeCats",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AdoptionCats",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }
    }
}