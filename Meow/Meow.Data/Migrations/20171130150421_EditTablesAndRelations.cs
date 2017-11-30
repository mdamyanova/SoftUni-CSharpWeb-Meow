using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Meow.Web.Data.Migrations
{
    public partial class EditTablesAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdopted",
                table: "Cats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Cats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Cats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cats_OwnerId",
                table: "Cats",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_AspNetUsers_OwnerId",
                table: "Cats",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_AspNetUsers_OwnerId",
                table: "Cats");

            migrationBuilder.DropIndex(
                name: "IX_Cats_OwnerId",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "IsAdopted",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
