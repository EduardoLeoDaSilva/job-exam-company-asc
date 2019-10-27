using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoApp.Migrations
{
    public partial class notasProva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Turmas",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Nota",
                table: "Provas",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Provas");
        }
    }
}
