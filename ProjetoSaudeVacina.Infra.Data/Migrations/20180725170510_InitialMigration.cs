using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    CEP = table.Column<string>(maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    PontoReferencia = table.Column<string>(maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacina",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostoSaude",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Latitude = table.Column<string>(maxLength: 30, nullable: true),
                    Longitude = table.Column<string>(maxLength: 30, nullable: true),
                    EnderecoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostoSaude", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostoSaude_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacinaEstoqueLancamento",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    PostoSaudeId = table.Column<long>(nullable: false),
                    VacinaId = table.Column<long>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacinaEstoqueLancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacinaEstoqueLancamento_PostoSaude_PostoSaudeId",
                        column: x => x.PostoSaudeId,
                        principalTable: "PostoSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VacinaEstoqueLancamento_Vacina_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostoSaude_EnderecoId",
                table: "PostoSaude",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PostoSaude_Nome",
                table: "PostoSaude",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_Nome",
                table: "Vacina",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VacinaEstoqueLancamento_PostoSaudeId",
                table: "VacinaEstoqueLancamento",
                column: "PostoSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacinaEstoqueLancamento_VacinaId",
                table: "VacinaEstoqueLancamento",
                column: "VacinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacinaEstoqueLancamento");

            migrationBuilder.DropTable(
                name: "PostoSaude");

            migrationBuilder.DropTable(
                name: "Vacina");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
