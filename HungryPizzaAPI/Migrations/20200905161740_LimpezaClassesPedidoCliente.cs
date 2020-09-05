using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class LimpezaClassesPedidoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_EnderecoEntrega_EnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_EnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.AlterColumn<string>(
                name: "DataPedido",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "Pedido",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPizza1 = table.Column<int>(type: "int", nullable: false),
                    IdPizza2 = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EnderecoEntregaId",
                table: "Pedido",
                column: "EnderecoEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_EnderecoEntrega_EnderecoEntregaId",
                table: "Pedido",
                column: "EnderecoEntregaId",
                principalTable: "EnderecoEntrega",
                principalColumn: "EnderecoEntregaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
