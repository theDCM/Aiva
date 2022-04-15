using Microsoft.EntityFrameworkCore.Migrations;

namespace Aiva.Migrations
{
    public partial class deletekitchenimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Kitchen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Kitchen",
                type: "text",
                nullable: true);
        }
    }
}
