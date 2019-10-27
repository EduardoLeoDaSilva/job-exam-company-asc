using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoApp.Migrations
{
    public partial class propriedadesAddedEmResultado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aprovado",
                table: "Resultados",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "NotaFinal",
                table: "Resultados",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprovado",
                table: "Resultados");

            migrationBuilder.DropColumn(
                name: "NotaFinal",
                table: "Resultados");
        }
    }
}
