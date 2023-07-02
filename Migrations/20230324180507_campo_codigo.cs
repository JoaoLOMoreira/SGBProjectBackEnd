using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SgbProject.Migrations
{
    public partial class campo_codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cod",
                table: "Bovinos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cod",
                table: "Bovinos");
        }
    }
}
