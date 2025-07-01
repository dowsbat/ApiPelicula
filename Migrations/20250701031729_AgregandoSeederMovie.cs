using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiPelicula.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoSeederMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Duracion", "Estreno", "GeneroId", "Rating", "Sinopsis", "Titulo" },
                values: new object[,]
                {
                    { 1, "George Miller", 120, 2015, 10, 8.0999999999999996, "En un futuro postapocalíptico, Max se une a una misteriosa mujer para huir de un tirano.", "Mad Max: Fury Road" },
                    { 2, "Steven Spielberg", 130, 1981, 20, 8.4000000000000004, "El arqueólogo Indiana Jones busca el Arca de la Alianza antes que los nazis.", "Indiana Jones y los cazadores del arca perdida" },
                    { 3, "Greg Mottola", 100, 2007, 30, 7.5999999999999996, "Dos amigos intentan disfrutar su última fiesta antes de graduarse.", "Superbad" },
                    { 4, "Francis Ford Coppola", 180, 1972, 40, 9.1999999999999993, "La historia de la familia mafiosa Corleone.", "El Padrino" },
                    { 5, "Peter Jackson", 187, 2001, 50, 8.8000000000000007, "Un hobbit debe destruir un anillo para salvar la Tierra Media.", "El Señor de los Anillos: La Comunidad del Anillo" },
                    { 6, "Christopher Nolan", 180, 2014, 60, 8.5999999999999996, "Un grupo de astronautas viaja a través de un agujero de gusano en busca de un nuevo hogar para la humanidad.", "Interestelar" },
                    { 7, "James Wan", 120, 2013, 70, 7.5, "Investigadores paranormales ayudan a una familia aterrorizada por una presencia oscura.", "El Conjuro" },
                    { 8, "James Cameron", 160, 1997, 80, 7.7999999999999998, "Una historia de amor a bordo del trágico Titanic.", "Titanic" },
                    { 9, "James Gunn", 140, 2014, 10, 8.0, "Un grupo de inadaptados se une para salvar la galaxia.", "Guardianes de la Galaxia" },
                    { 10, "Damien Chazelle", 120, 2016, 40, 8.0, "Un pianista y una actriz persiguen sus sueños en Los Ángeles.", "La La Land" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
