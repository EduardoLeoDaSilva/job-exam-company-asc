using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoApp.Migrations
{
    public partial class EntidadeProvaAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prova",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "Prova1",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "Prova2",
                table: "Materias");

            migrationBuilder.CreateTable(
                name: "Provas",
                columns: table => new
                {
                    ProvaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Peso = table.Column<double>(nullable: false),
                    MateriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provas", x => x.ProvaId);
                    table.ForeignKey(
                        name: "FK_Provas_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provas_MateriaId",
                table: "Provas",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provas");

            migrationBuilder.AddColumn<string>(
                name: "Prova",
                table: "Materias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prova1",
                table: "Materias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prova2",
                table: "Materias",
                nullable: true);
        }
    }
}
