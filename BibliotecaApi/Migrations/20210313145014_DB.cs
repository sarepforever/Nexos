using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaApi.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    idAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    ciudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    mail = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.idAutor);
                });

            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    idEditorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    mail = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    numLibros = table.Column<int>(type: "int", nullable: true, defaultValue: -1),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.idEditorial);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    idLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    genero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    numPag = table.Column<int>(type: "int", nullable: false),
                    idEditorial = table.Column<int>(type: "int", nullable: false),
                    idAutor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.idLibro);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_idAutor",
                        column: x => x.idAutor,
                        principalTable: "Autor",
                        principalColumn: "idAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libro_Editorial_idEditorial",
                        column: x => x.idEditorial,
                        principalTable: "Editorial",
                        principalColumn: "idEditorial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_idAutor",
                table: "Libro",
                column: "idAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_idEditorial",
                table: "Libro",
                column: "idEditorial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Editorial");
        }
    }
}
