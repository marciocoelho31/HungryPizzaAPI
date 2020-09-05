using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class RelacionamentoClienteEnderecoEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_EnderecoEntrega_EnderecoEntregaId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_EnderecoEntrega_IdEnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdEnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoEntrega",
                table: "EnderecoEntrega");

            migrationBuilder.DropColumn(
                name: "IdEnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EnderecoEntrega");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPedido",
                table: "Pedido",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EnderecoEntregaId",
                table: "Pedido",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoEntregaId",
                table: "EnderecoEntrega",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoEntrega",
                table: "EnderecoEntrega",
                column: "EnderecoEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EnderecoEntregaId",
                table: "Pedido",
                column: "EnderecoEntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_EnderecoEntrega_EnderecoEntregaId",
                table: "Cliente",
                column: "EnderecoEntregaId",
                principalTable: "EnderecoEntrega",
                principalColumn: "EnderecoEntregaId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Cliente_EnderecoEntrega_EnderecoEntregaId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_EnderecoEntrega_EnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_EnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoEntrega",
                table: "EnderecoEntrega");

            migrationBuilder.DropColumn(
                name: "DataPedido",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "EnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "EnderecoEntregaId",
                table: "EnderecoEntrega");

            migrationBuilder.AddColumn<int>(
                name: "IdEnderecoEntregaId",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EnderecoEntrega",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoEntrega",
                table: "EnderecoEntrega",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdEnderecoEntregaId",
                table: "Pedido",
                column: "IdEnderecoEntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_EnderecoEntrega_EnderecoEntregaId",
                table: "Cliente",
                column: "EnderecoEntregaId",
                principalTable: "EnderecoEntrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_EnderecoEntrega_IdEnderecoEntregaId",
                table: "Pedido",
                column: "IdEnderecoEntregaId",
                principalTable: "EnderecoEntrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
