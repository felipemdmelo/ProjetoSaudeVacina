using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class RemoveVacinaEstoqueItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacinaEstoqueItem");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "VacinaEstoque",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "VacinaId",
                table: "VacinaEstoque",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_VacinaEstoque_VacinaId",
                table: "VacinaEstoque",
                column: "VacinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VacinaEstoque_Vacina_VacinaId",
                table: "VacinaEstoque",
                column: "VacinaId",
                principalTable: "Vacina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacinaEstoque_Vacina_VacinaId",
                table: "VacinaEstoque");

            migrationBuilder.DropIndex(
                name: "IX_VacinaEstoque_VacinaId",
                table: "VacinaEstoque");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "VacinaEstoque");

            migrationBuilder.DropColumn(
                name: "VacinaId",
                table: "VacinaEstoque");

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
                name: "IX_VacinaEstoqueItem_VacinaEstoqueId",
                table: "VacinaEstoqueItem",
                column: "VacinaEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_VacinaEstoqueItem_VacinaId",
                table: "VacinaEstoqueItem",
                column: "VacinaId");
        }
    }
}
