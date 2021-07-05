using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class IDproblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpacePortID",
                table: "ParkingSessions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpacePortID",
                table: "ParkingSessions");
        }
    }
}
