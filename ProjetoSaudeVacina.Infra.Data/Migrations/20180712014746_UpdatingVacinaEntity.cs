using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class UpdatingVacinaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Vacina",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Vacina",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
