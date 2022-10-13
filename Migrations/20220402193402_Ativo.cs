using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIFibra.Migrations
{
    public partial class Ativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.CreateTable(
                name: "FibraAtivo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeAtivo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ultimo = table.Column<float>(type: "real", nullable: false),
                    Minimo = table.Column<float>(type: "real", nullable: false),
                    Maximo = table.Column<float>(type: "real", nullable: false),
                    Variacao = table.Column<float>(type: "real", nullable: false),
                    Medio = table.Column<float>(type: "real", nullable: false),
                    Abertura = table.Column<float>(type: "real", nullable: false),
                    Fechamento = table.Column<float>(type: "real", nullable: false),
                    Negocios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Compra = table.Column<float>(type: "real", nullable: false),
                    Venda = table.Column<float>(type: "real", nullable: false),
                    QCompra = table.Column<float>(type: "real", nullable: false),
                    QVenda = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FibraAtivo", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FibraAtivo_Data_NomeAtivo",
                table: "FibraAtivo",
                columns: new[] { "Data", "NomeAtivo" });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FibraAtivo");
        }
    }
}
