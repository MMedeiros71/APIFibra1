using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIFibra.Migrations
{
    public partial class cotaindicemodificado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.CreateTable(
                name: "FibraCotaIndice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCota = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorCota = table.Column<float>(type: "real", nullable: false),
                    CotaOficial = table.Column<bool>(type: "bit", nullable: false),
                    RentabilidadeDia = table.Column<float>(type: "real", nullable: false),
                    RentabilidadeMes = table.Column<float>(type: "real", nullable: false),
                    RentabilidadeAno = table.Column<float>(type: "real", nullable: false),
                    RentabilidadeUltimosMeses = table.Column<float>(type: "real", nullable: false),
                    DataFGTSVale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorFGTSVale = table.Column<float>(type: "real", nullable: false),
                    DataFundoFibraMulticarteira = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorFundoFibraMulticarteira = table.Column<float>(type: "real", nullable: false),
                    PatrimonioLiquidoFibraMulticarteira = table.Column<float>(type: "real", nullable: false),
                    DataFundoPremium = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorFundoPremium = table.Column<float>(type: "real", nullable: false),
                    PatrimonioLiquidoFundoPremium = table.Column<float>(type: "real", nullable: false),
                    DataPatrimonio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorCotaPatrimonio = table.Column<float>(type: "real", nullable: false),
                    ValorPatrimonioAtual = table.Column<int>(type: "int", nullable: false),
                    ValorPatrimonioMedio = table.Column<int>(type: "int", nullable: false),
                    SelicValor = table.Column<float>(type: "real", nullable: false),
                    SelicVariacao = table.Column<float>(type: "real", nullable: false),
                    TJLPValor = table.Column<float>(type: "real", nullable: false),
                    TJLPVariacao = table.Column<float>(type: "real", nullable: false),
                    CDB30Valor = table.Column<float>(type: "real", nullable: false),
                    CDB30Variacao = table.Column<float>(type: "real", nullable: false),
                    IGPMValor = table.Column<float>(type: "real", nullable: false),
                    IGPMVariacao = table.Column<float>(type: "real", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FibraCotaIndice", x => x.ID);
                });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FibraCotaIndice");
        }
    }
}
