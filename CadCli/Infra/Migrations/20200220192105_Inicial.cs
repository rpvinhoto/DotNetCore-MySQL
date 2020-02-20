using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(9)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Numero = table.Column<int>(nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Bairro", "Cep", "Cidade", "Complemento", "DataNascimento", "Endereco", "Estado", "Nome", "Numero", "Sexo" },
                values: new object[] { 1L, "Centro", "86975-000", "Mandaguari", "B", new DateTime(1950, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avenida Amazonas", "PR", "Maria Oliveira", 123, 0 });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Bairro", "Cep", "Cidade", "Complemento", "DataNascimento", "Endereco", "Estado", "Nome", "Numero", "Sexo" },
                values: new object[] { 2L, "Zona 01", "87013-210", "Maringá", null, new DateTime(1983, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Av. Tamandaré", "PR", "José da Silva", 100, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
