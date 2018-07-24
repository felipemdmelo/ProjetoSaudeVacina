using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class SetNomeColumnStringLength30ForPostoSaude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PostoSaude",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PostoSaude",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
