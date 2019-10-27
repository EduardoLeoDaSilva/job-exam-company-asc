using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoApp.Migrations
{
    public partial class RelNpnAlunoMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Alunos_AlunoId",
                table: "Materias");

            migrationBuilder.DropIndex(
                name: "IX_Materias_AlunoId",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Materias");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Provas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MateriaAluno",
                columns: table => new
                {
                    MateriaId = table.Column<int>(nullable: false),
                    AlunoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaAluno", x => new { x.MateriaId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_MateriaAluno_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaAluno_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provas_AlunoId",
                table: "Provas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAluno_AlunoId",
                table: "MateriaAluno",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Provas_Alunos_AlunoId",
                table: "Provas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provas_Alunos_AlunoId",
                table: "Provas");

            migrationBuilder.DropTable(
                name: "MateriaAluno");

            migrationBuilder.DropIndex(
                name: "IX_Provas_AlunoId",
                table: "Provas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Provas");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Materias",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_AlunoId",
                table: "Materias",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Alunos_AlunoId",
                table: "Materias",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
