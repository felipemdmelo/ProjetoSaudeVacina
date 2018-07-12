using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacina",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacinaEstoque",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacinaEstoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostoSaude",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Latitude = table.Column<long>(nullable: false),
                    Longitude = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    VacinaEstoqueId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostoSaude", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostoSaude_VacinaEstoque_VacinaEstoqueId",
                        column: x => x.VacinaEstoqueId,
                        principalTable: "VacinaEstoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacinaEstoqueItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    VacinaEstoqueId = table.Column<long>(nullable: false),
                    VacinaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacinaEstoqueItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacinaEstoqueItem_VacinaEstoque_VacinaEstoqueId",
                        column: x => x.VacinaEstoqueId,
                        principalTable: "VacinaEstoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacinaEstoqueItem_Vacina_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostoSaude_VacinaEstoqueId",
                table: "PostoSaude",
                column: "VacinaEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_VacinaEstoqueItem_VacinaEstoqueId",
                table: "VacinaEstoqueItem",
                column: "VacinaEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_VacinaEstoqueItem_VacinaId",
                table: "VacinaEstoqueItem",
                column: "VacinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostoSaude");

            migrationBuilder.DropTable(
                name: "VacinaEstoqueItem");

            migrationBuilder.DropTable(
                name: "VacinaEstoque");

            migrationBuilder.DropTable(
                name: "Vacina");
        }
    }
}
