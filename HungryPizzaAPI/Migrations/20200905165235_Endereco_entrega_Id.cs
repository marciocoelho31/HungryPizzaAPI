using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class Endereco_entrega_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_EnderecoEntrega_EnderecoEntregaId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_EnderecoEntrega_EnderecoEntregaId",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoEntrega",
                table: "EnderecoEntrega");

            migrationBuilder.DropColumn(
                name: "EnderecoEntregaId",
                table: "EnderecoEntrega");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EnderecoEntrega",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoEntrega",
                table: "EnderecoEntrega",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_EnderecoEntrega_EnderecoEntregaId",
                table: "Cliente",
                column: "EnderecoEntregaId",
                principalTable: "EnderecoEntrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_EnderecoEntrega_EnderecoEntregaId",
                table: "Pedido",
                column: "EnderecoEntregaId",
                principalTable: "EnderecoEntrega",
                principalColumn: "Id",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoEntrega",
                table: "EnderecoEntrega");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EnderecoEntrega");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoEntregaId",
                table: "EnderecoEntrega",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoEntrega",
                table: "EnderecoEntrega",
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
    }
}
