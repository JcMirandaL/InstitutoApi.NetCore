using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstitutoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class agregoCampoFechaMatruicula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaMatrucla",
                table: "tbMatriculas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaMatrucla",
                table: "tbMatriculas");
        }
    }
}
