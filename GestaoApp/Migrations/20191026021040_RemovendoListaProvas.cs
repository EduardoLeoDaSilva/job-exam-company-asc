using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoApp.Migrations
{
    public partial class RemovendoListaProvas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso1",
                table: "Materias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Peso2",
                table: "Materias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Peso3",
                table: "Materias",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso1",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "Peso2",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "Peso3",
                table: "Materias");
        }
    }
}
