using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class pedidoitem_pizza_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPizza1",
                table: "PedidoItem");

            migrationBuilder.DropColumn(
                name: "IdPizza2",
                table: "PedidoItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPizza1",
                table: "PedidoItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPizza2",
                table: "PedidoItem",
                type: "int",
                nullable: true);
        }
    }
}
