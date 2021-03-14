using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaApi.Migrations
{
    public partial class DBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Editorial_idEditorial",
                table: "Libro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Editorial",
                table: "Editorial");

            migrationBuilder.RenameTable(
                name: "Editorial",
                newName: "Editoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Editoria",
                table: "Editoria",
                column: "idEditorial");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Editoria_idEditorial",
                table: "Libro",
                column: "idEditorial",
                principalTable: "Editoria",
                principalColumn: "idEditorial",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Editoria_idEditorial",
                table: "Libro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Editoria",
                table: "Editoria");

            migrationBuilder.RenameTable(
                name: "Editoria",
                newName: "Editorial");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Editorial",
                table: "Editorial",
                column: "idEditorial");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Editorial_idEditorial",
                table: "Libro",
                column: "idEditorial",
                principalTable: "Editorial",
                principalColumn: "idEditorial",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
