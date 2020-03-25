using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class ParkingSpotSpacePortNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_SpacePorts_SpacePortID",
                table: "ParkingSpots");

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingSpots",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_SpacePorts_SpacePortID",
                table: "ParkingSpots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_SpacePorts_SpacePortID",
                table: "ParkingSpots");

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingSpots",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_SpacePorts_SpacePortID",
                table: "ParkingSpots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
