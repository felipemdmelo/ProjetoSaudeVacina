using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class AlteringLatLngDataTypeForPostoSaudeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "PostoSaude",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "PostoSaude",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Longitude",
                table: "PostoSaude",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Latitude",
                table: "PostoSaude",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
