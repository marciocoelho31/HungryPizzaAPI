using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class PopularTabelaPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sabor = table.Column<string>(maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                });
        
            migrationBuilder.Sql("INSERT INTO Pizza (Sabor,Descricao,Preco) VALUES('3 Queijos','Saborosa pizza de 3 queijos, com mussarela, catupiry e gorgonzola!', 50)");
            migrationBuilder.Sql("INSERT INTO Pizza (Sabor,Descricao,Preco) VALUES('Frango com requeijão','Deliciosa pizza de frango desfiado com requeijão!', 59.99)");
            migrationBuilder.Sql("INSERT INTO Pizza (Sabor,Descricao,Preco) VALUES('Mussarela','Aquela pizza de mussarela que agrada todo mundo!', 42.5)");
            migrationBuilder.Sql("INSERT INTO Pizza (Sabor,Descricao,Preco) VALUES('Calabresa','Magnífica pizza calabresa feita com linguiça artesanal!', 42.5)");
            migrationBuilder.Sql("INSERT INTO Pizza (Sabor,Descricao,Preco) VALUES('Pepperoni','Absurdamente gostosa pizza feita com pepperoni da melhor qualidade!', 55)");
            migrationBuilder.Sql("INSERT INTO Pizza (Sabor,Descricao,Preco) VALUES('Portuguesa','Pizza tradicional portuguesa com bastante presunto, azeitonas, ovos, cebola, linguiça e orégano!', 45)");
            migrationBuilder.Sql("INSERT INTO Pizza (Sabor,Descricao,Preco) VALUES('Veggie','Pizza vegetariana pra ninguém ficar sem comer pizza na hora do aperto, com abobrinha, shitake e alho poró!', 59.99)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Pizza");
            migrationBuilder.DropTable(
                name: "Pizza");
        }
    }
}
