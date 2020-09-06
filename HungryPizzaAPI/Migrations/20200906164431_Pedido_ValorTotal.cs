using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class Pedido_ValorTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Pedido",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedido");
        }
    }
}
