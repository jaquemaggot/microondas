using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class CriandoProgramasAquecimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramasAquecimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoPrograma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aquecimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tempo = table.Column<int>(type: "int", nullable: false),
                    Potencia = table.Column<int>(type: "int", nullable: false),
                    StringDeAquecimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstrucoesComplementares = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Padrao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramasAquecimento", x => x.Id);
                });

            migrationBuilder.InsertData(
            table: "ProgramasAquecimento",
            columns: new[] { "NomeDoPrograma","Alimento","Aquecimento","Tempo","Potencia","StringDeAquecimento","InstrucoesComplementares","Padrao" },
            values: new object[,]
            {
                { "Pipoca", "Pipoca (de micro-ondas)", "3 minutos", 180,7,"*","Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento.", true },

                { "Leite","Leite","5 minutos",300, 7,"&" ,"Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras.", true},
                { "Carnes de boi", " Carne em pedaço ou fatias","14 minutos",840,4,"/"," Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.", true},
                {"Frango","Frango (qualquer corte)", "8 minutos",480,7,"-"," Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.", true},
                {"Feijão", " Feijão congelado", "8 minutos", 480,9, "#"," Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.",true }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramasAquecimento");
        }
    }
}
