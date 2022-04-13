using Microsoft.EntityFrameworkCore.Migrations;

namespace Aiva.Migrations
{
    public partial class LoginPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Cooks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Cooks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Clients",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Clients");
        }
    }
}
