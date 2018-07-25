using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSaudeVacina.Infra.Data.Migrations
{
    public partial class AddStatusAndDataInativacaoForAbstractEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInativacao",
                table: "VacinaEstoqueLancamento",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "VacinaEstoqueLancamento",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInativacao",
                table: "Vacina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "Vacina",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInativacao",
                table: "PostoSaude",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "PostoSaude",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInativacao",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "Pessoa",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInativacao",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "Endereco",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CPF",
                table: "Pessoa",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Email",
                table: "Pessoa",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoa_CPF",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_Email",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DataInativacao",
                table: "VacinaEstoqueLancamento");

            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "VacinaEstoqueLancamento");

            migrationBuilder.DropColumn(
                name: "DataInativacao",
                table: "Vacina");

            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "Vacina");

            migrationBuilder.DropColumn(
                name: "DataInativacao",
                table: "PostoSaude");

            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "PostoSaude");

            migrationBuilder.DropColumn(
                name: "DataInativacao",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DataInativacao",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "Endereco");
        }
    }
}
