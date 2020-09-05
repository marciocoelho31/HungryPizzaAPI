using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class Pedido_endereco_entrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EnderecoEntregaId",
                table: "Pedido",
                column: "EnderecoEntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_EnderecoEntrega_EnderecoEntregaId",
                table: "Pedido",
                column: "EnderecoEntregaId",
                principalTable: "EnderecoEntrega",
                principalColumn: "EnderecoEntregaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_EnderecoEntrega_EnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_EnderecoEntregaId",
                table: "Pedido");
        }
    }
}
