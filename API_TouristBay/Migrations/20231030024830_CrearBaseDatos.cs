using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_TouristBay.Migrations
{
    /// <inheritdoc />
    public partial class CrearBaseDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pasajero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aerolinea = table.Column<int>(type: "int", nullable: false),
                    Clase = table.Column<bool>(type: "bit", nullable: false),
                    Destino = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<int>(type: "int", nullable: false),
                    PlzEconomicas = table.Column<int>(type: "int", nullable: false),
                    PlzPreferenciales = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pasajero",
                columns: new[] { "Id", "Apellido", "Genero", "Nombre" },
                values: new object[] { 1, "default", false, "default" });

            migrationBuilder.InsertData(
                table: "Vuelo",
                columns: new[] { "Id", "Aerolinea", "Clase", "Destino", "Origen", "PlzEconomicas", "PlzPreferenciales", "Precio" },
                values: new object[] { 1, 0, false, 0, 0, 0, 0, 0.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pasajero");

            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}
