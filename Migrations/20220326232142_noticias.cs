using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIFibra.Migrations
{
    public partial class noticias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.CreateTable(
                name: "FibraNoticias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<short>(type: "smallint", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FibraNoticias", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FibraNoticias_Data",
                table: "FibraNoticias",
                column: "Data");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FibraNoticias");
        }
    }
}
