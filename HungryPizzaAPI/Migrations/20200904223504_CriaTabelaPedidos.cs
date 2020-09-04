using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class CriaTabelaPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    NomeCliente = table.Column<string>(nullable: true),
                    IdEnderecoEntregaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_EnderecoEntrega_IdEnderecoEntregaId",
                        column: x => x.IdEnderecoEntregaId,
                        principalTable: "EnderecoEntrega",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdEnderecoEntregaId",
                table: "Pedido",
                column: "IdEnderecoEntregaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
