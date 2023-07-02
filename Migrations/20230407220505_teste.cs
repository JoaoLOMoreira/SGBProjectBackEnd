using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SgbProject.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cod",
                table: "Bovinos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cod",
                table: "Bovinos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
