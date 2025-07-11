﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPelicula.Migrations
{
    /// <inheritdoc />
    public partial class AddDuracionMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duracion",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Movies");
        }
    }
}
