using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestionale_Libreria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generi",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descrizione = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Libreria",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<char>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libreria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Libri",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    titolo = table.Column<string>(type: "TEXT", nullable: true),
                    prestito = table.Column<bool>(type: "INTEGER", nullable: false),
                    idGenere = table.Column<int>(type: "INTEGER", nullable: false),
                    idScaffale = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libri", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Generi");

            migrationBuilder.DropTable(
                name: "Libreria");

            migrationBuilder.DropTable(
                name: "Libri");
        }
    }
}
