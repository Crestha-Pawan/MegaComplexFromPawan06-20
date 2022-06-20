using Microsoft.EntityFrameworkCore.Migrations;

namespace FiboInfraStructure.Migrations
{
    public partial class dvjk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDue",
                table: "Billings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDue",
                table: "Billings");
        }
    }
}
