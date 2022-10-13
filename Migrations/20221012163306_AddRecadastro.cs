using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIFibra.Migrations
{
    public partial class AddRecadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FibraRecadastro",
                columns: table => new
                {
                    Numcotista = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndComp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiliacaoPai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiliacaoMae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocalNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegimeBens = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentOrgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentEmissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeConjuge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfConjuge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEmail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaixaPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OcupacaoProfissional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profissao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntidadeTrabalhoCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntidadeTrabalhoCnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntidadeTrabalhoNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntidadeTrabalhoTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemuneracaoMensal = table.Column<float>(type: "real", nullable: true),
                    OutrasRendas = table.Column<float>(type: "real", nullable: true),
                    Patrimonio = table.Column<float>(type: "real", nullable: true),
                    BancoTipoConta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BancoNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BancoNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BancoConta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperaTerceiros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransmissaoOrdens = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConhecimentoFinanceiro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcuradorNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcuradorCpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcuradorInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcuradorFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AutorizadoNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorizadoCpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorizadoInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AutorizadoFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Poderes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PessoaPolitica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesempenhoCargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticoOrgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticoCargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticoInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PoliticoFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PoliticoVinculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticoNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticoCpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticoNatureza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proposito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmitirExtrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerfilInvestidor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerfilData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FibraRecadastro", x => x.Numcotista);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FibraRecadastro");
        }
    }
}
