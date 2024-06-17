using Microsoft.EntityFrameworkCore.Migrations;

namespace CarrosMVC.Migrations
{
    public partial class RemoveMarcaIdFromModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Modelos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Modelos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
