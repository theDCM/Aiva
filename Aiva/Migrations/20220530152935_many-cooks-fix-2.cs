using Microsoft.EntityFrameworkCore.Migrations;

namespace Aiva.Migrations
{
    public partial class manycooksfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CookOrder",
                columns: table => new
                {
                    CooksId = table.Column<int>(type: "integer", nullable: false),
                    OrdersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookOrder", x => new { x.CooksId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_CookOrder_Cooks_CooksId",
                        column: x => x.CooksId,
                        principalTable: "Cooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookOrder_OrdersId",
                table: "CookOrder",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookOrder");

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
    }
}
