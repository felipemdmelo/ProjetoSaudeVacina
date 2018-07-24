using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class SetNomeColumnUniqueForPostoSaude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PostoSaude",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_PostoSaude_Nome",
                table: "PostoSaude",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PostoSaude_Nome",
                table: "PostoSaude");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PostoSaude",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
