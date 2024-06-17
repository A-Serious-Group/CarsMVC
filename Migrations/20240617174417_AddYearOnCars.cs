using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarrosMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddYearOnCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Carros",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Carros");
        }
    }
}
