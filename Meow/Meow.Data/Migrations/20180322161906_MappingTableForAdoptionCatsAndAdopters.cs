using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Meow.Data.Migrations
{
    public partial class MappingTableForAdoptionCatsAndAdopters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdoptionCatUser",
                columns: table => new
                {
                    AdoptionCatId = table.Column<int>(nullable: false),
                    AdopterId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionCatUser", x => new { x.AdoptionCatId, x.AdopterId });
                    table.ForeignKey(
                        name: "FK_AdoptionCatUser_AspNetUsers_AdopterId",
                        column: x => x.AdopterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdoptionCatUser_AdoptionCats_AdoptionCatId",
                        column: x => x.AdoptionCatId,
                        principalTable: "AdoptionCats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionCatUser_AdopterId",
                table: "AdoptionCatUser",
                column: "AdopterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionCatUser");
        }
    }
}
