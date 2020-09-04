using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class CorrigeIdEnderecoEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_EnderecoEntrega_IdEnderecoEntregaId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdEnderecoEntregaId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdEnderecoEntregaId",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "IdEnderecoEntrega",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEnderecoEntrega",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "IdEnderecoEntregaId",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdEnderecoEntregaId",
                table: "Cliente",
                column: "IdEnderecoEntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_EnderecoEntrega_IdEnderecoEntregaId",
                table: "Cliente",
                column: "IdEnderecoEntregaId",
                principalTable: "EnderecoEntrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
