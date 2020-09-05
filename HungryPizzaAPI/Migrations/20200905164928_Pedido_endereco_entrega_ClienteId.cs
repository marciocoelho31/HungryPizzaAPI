using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class Pedido_endereco_entrega_ClienteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoEntregaId",
                table: "Cliente",
                column: "EnderecoEntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_EnderecoEntrega_EnderecoEntregaId",
                table: "Cliente",
                column: "EnderecoEntregaId",
                principalTable: "EnderecoEntrega",
                principalColumn: "EnderecoEntregaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_EnderecoEntrega_EnderecoEntregaId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_EnderecoEntregaId",
                table: "Cliente");
        }
    }
}
