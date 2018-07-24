using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class UpdatingRelationshipsBetweenPostoSaudeEVacinaEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostoSaude_VacinaEstoque_VacinaEstoqueId",
                table: "PostoSaude");

            migrationBuilder.DropIndex(
                name: "IX_PostoSaude_VacinaEstoqueId",
                table: "PostoSaude");

            migrationBuilder.DropColumn(
                name: "VacinaEstoqueId",
                table: "PostoSaude");

            migrationBuilder.AddColumn<long>(
                name: "PostoSaudeId",
                table: "VacinaEstoque",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_VacinaEstoque_PostoSaudeId",
                table: "VacinaEstoque",
                column: "PostoSaudeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VacinaEstoque_PostoSaude_PostoSaudeId",
                table: "VacinaEstoque",
                column: "PostoSaudeId",
                principalTable: "PostoSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacinaEstoque_PostoSaude_PostoSaudeId",
                table: "VacinaEstoque");

            migrationBuilder.DropIndex(
                name: "IX_VacinaEstoque_PostoSaudeId",
                table: "VacinaEstoque");

            migrationBuilder.DropColumn(
                name: "PostoSaudeId",
                table: "VacinaEstoque");

            migrationBuilder.AddColumn<long>(
                name: "VacinaEstoqueId",
                table: "PostoSaude",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostoSaude_VacinaEstoqueId",
                table: "PostoSaude",
                column: "VacinaEstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostoSaude_VacinaEstoque_VacinaEstoqueId",
                table: "PostoSaude",
                column: "VacinaEstoqueId",
                principalTable: "VacinaEstoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
