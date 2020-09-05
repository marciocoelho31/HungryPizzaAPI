using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class pedidoitem_pizza_preco_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Pizza",
                newName: "PrecoSabor");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "PedidoItem",
                newName: "PrecoPizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoSabor",
                table: "Pizza",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "PrecoPizza",
                table: "PedidoItem",
                newName: "Preco");
        }
    }
}
