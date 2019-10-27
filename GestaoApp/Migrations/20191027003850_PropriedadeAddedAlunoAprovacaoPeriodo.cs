using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoApp.Migrations
{
    public partial class PropriedadeAddedAlunoAprovacaoPeriodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AprovadoPeriodo",
                table: "Alunos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AprovadoPeriodo",
                table: "Alunos");
        }
    }
}
