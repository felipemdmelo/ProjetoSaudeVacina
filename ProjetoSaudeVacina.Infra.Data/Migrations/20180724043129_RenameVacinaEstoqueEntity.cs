using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class RenameVacinaEstoqueEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacinaEstoque");

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacinaEstoqueLancamento_Vacina_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "VacinaEstoque",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    PostoSaudeId = table.Column<long>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    VacinaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacinaEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacinaEstoque_PostoSaude_PostoSaudeId",
                        column: x => x.PostoSaudeId,
                        principalTable: "PostoSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacinaEstoque_Vacina_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacinaEstoque_PostoSaudeId",
                table: "VacinaEstoque",
                column: "PostoSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacinaEstoque_VacinaId",
                table: "VacinaEstoque",
                column: "VacinaId");
        }
    }
}
