using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class pedidoitem_pizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pizza1Id",
                table: "PedidoItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pizza2Id",
                table: "PedidoItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_Pizza1Id",
                table: "PedidoItem",
                column: "Pizza1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_Pizza2Id",
                table: "PedidoItem",
                column: "Pizza2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Pizza_Pizza1Id",
                table: "PedidoItem",
                column: "Pizza1Id",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Pizza_Pizza2Id",
                table: "PedidoItem",
                column: "Pizza2Id",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Pizza_Pizza1Id",
                table: "PedidoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Pizza_Pizza2Id",
                table: "PedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_PedidoItem_Pizza1Id",
                table: "PedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_PedidoItem_Pizza2Id",
                table: "PedidoItem");

            migrationBuilder.DropColumn(
                name: "Pizza1Id",
                table: "PedidoItem");

            migrationBuilder.DropColumn(
                name: "Pizza2Id",
                table: "PedidoItem");
        }
    }
}
