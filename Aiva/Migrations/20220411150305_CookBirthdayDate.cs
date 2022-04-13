using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aiva.Migrations
{
    public partial class CookBirthdayDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cooks",
                newName: "LastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthdayDate",
                table: "Cooks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Cooks",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthdayDate",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Cooks");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Cooks",
                newName: "Name");
        }
    }
}
