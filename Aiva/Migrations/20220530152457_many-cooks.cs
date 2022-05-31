using Microsoft.EntityFrameworkCore.Migrations;

namespace Aiva.Migrations
{
    public partial class manycooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cooks_CookId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CookId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CookId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Cooks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_OrderId",
                table: "Cooks",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooks_Orders_OrderId",
                table: "Cooks",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooks_Orders_OrderId",
                table: "Cooks");

            migrationBuilder.DropIndex(
                name: "IX_Cooks_OrderId",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Cooks");

            migrationBuilder.AddColumn<int>(
                name: "CookId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CookId",
                table: "Orders",
                column: "CookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cooks_CookId",
                table: "Orders",
                column: "CookId",
                principalTable: "Cooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
