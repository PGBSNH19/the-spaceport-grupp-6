using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class added_SSN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_SpacePorts_SpacePortID",
                table: "ParkingSpots");

            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "Persons",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingSpots",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_SpacePorts_SpacePortID",
                table: "ParkingSpots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_SpacePorts_SpacePortID",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingSpots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_SpacePorts_SpacePortID",
                table: "ParkingSpots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
