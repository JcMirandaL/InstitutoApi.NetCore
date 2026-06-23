using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstitutoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class nombreTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Cursos_CursoId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_tbEstudiantes_EstudianteCedula",
                table: "Matriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.RenameTable(
                name: "Matriculas",
                newName: "tbMatriculas");

            migrationBuilder.RenameTable(
                name: "Cursos",
                newName: "tbCursos");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_EstudianteCedula",
                table: "tbMatriculas",
                newName: "IX_tbMatriculas_EstudianteCedula");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_CursoId",
                table: "tbMatriculas",
                newName: "IX_tbMatriculas_CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cursos_Nombre",
                table: "tbCursos",
                newName: "IX_tbCursos_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbMatriculas",
                table: "tbMatriculas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbCursos",
                table: "tbCursos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbMatriculas_tbCursos_CursoId",
                table: "tbMatriculas",
                column: "CursoId",
                principalTable: "tbCursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbMatriculas_tbEstudiantes_EstudianteCedula",
                table: "tbMatriculas",
                column: "EstudianteCedula",
                principalTable: "tbEstudiantes",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbMatriculas_tbCursos_CursoId",
                table: "tbMatriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_tbMatriculas_tbEstudiantes_EstudianteCedula",
                table: "tbMatriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbMatriculas",
                table: "tbMatriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbCursos",
                table: "tbCursos");

            migrationBuilder.RenameTable(
                name: "tbMatriculas",
                newName: "Matriculas");

            migrationBuilder.RenameTable(
                name: "tbCursos",
                newName: "Cursos");

            migrationBuilder.RenameIndex(
                name: "IX_tbMatriculas_EstudianteCedula",
                table: "Matriculas",
                newName: "IX_Matriculas_EstudianteCedula");

            migrationBuilder.RenameIndex(
                name: "IX_tbMatriculas_CursoId",
                table: "Matriculas",
                newName: "IX_Matriculas_CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_tbCursos_Nombre",
                table: "Cursos",
                newName: "IX_Cursos_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Cursos_CursoId",
                table: "Matriculas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_tbEstudiantes_EstudianteCedula",
                table: "Matriculas",
                column: "EstudianteCedula",
                principalTable: "tbEstudiantes",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
