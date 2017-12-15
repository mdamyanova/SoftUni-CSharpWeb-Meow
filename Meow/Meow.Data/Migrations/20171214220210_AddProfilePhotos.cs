namespace Meow.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddProfilePhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePhoto",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                table: "AspNetUsers");
        }
    }
}