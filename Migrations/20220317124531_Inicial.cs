using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIFibra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.CreateTable(
                name: "FibraAdministrativo",
                columns: table => new
                {
                    Usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nivel = table.Column<byte>(type: "tinyint", nullable: false),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FibraAdministrativo", x => x.Usuario);
                });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FibraAdministrativo");
        }
    }
}
