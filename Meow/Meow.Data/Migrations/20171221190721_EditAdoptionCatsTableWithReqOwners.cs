namespace Meow.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EditAdoptionCatsTableWithReqOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePhoto",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestedOwnerId",
                table: "AdoptionCats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedOwnerId",
                table: "AdoptionCats");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePhoto",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(byte[]));
        }
    }
}