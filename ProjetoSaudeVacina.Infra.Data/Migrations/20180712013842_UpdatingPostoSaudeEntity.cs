using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class UpdatingPostoSaudeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostoSaude_VacinaEstoque_VacinaEstoqueId",
                table: "PostoSaude");

            migrationBuilder.AlterColumn<long>(
                name: "VacinaEstoqueId",
                table: "PostoSaude",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PostoSaude",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostoSaude_VacinaEstoque_VacinaEstoqueId",
                table: "PostoSaude",
                column: "VacinaEstoqueId",
                principalTable: "VacinaEstoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostoSaude_VacinaEstoque_VacinaEstoqueId",
                table: "PostoSaude");

            migrationBuilder.AlterColumn<long>(
                name: "VacinaEstoqueId",
                table: "PostoSaude",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PostoSaude",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_PostoSaude_VacinaEstoque_VacinaEstoqueId",
                table: "PostoSaude",
                column: "VacinaEstoqueId",
                principalTable: "VacinaEstoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
