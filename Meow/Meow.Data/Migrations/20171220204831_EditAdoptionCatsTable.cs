namespace Meow.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EditAdoptionCatsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "HomeCats",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequested",
                table: "AdoptionCats",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRequested",
                table: "AdoptionCats");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "HomeCats",
                nullable: true,
                oldClrType: typeof(byte[]));
        }
    }
}