using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class relacionamentousuarioendereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoRua = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    SiglaEstado = table.Column<string>(type: "nvarchar(240)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroContado = table.Column<string>(type: "nvarchar(240)", nullable: true),
                    IdEndereco = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEndereco",
                table: "Usuarios",
                column: "IdEndereco",
                unique: true,
                filter: "[IdEndereco] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
