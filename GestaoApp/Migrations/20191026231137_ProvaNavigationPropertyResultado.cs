using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoApp.Migrations
{
    public partial class ProvaNavigationPropertyResultado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultadoId",
                table: "Provas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provas_ResultadoId",
                table: "Provas",
                column: "ResultadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Provas_Resultados_ResultadoId",
                table: "Provas",
                column: "ResultadoId",
                principalTable: "Resultados",
                principalColumn: "ResultadoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provas_Resultados_ResultadoId",
                table: "Provas");

            migrationBuilder.DropIndex(
                name: "IX_Provas_ResultadoId",
                table: "Provas");

            migrationBuilder.DropColumn(
                name: "ResultadoId",
                table: "Provas");
        }
    }
}
