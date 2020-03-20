using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class ISpaceShipID_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StarShip",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "StarShipID",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "ValidUntil",
                table: "ParkingSessions");

            migrationBuilder.AddColumn<int>(
                name: "SpaceShipID",
                table: "StarShip",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarShip",
                table: "StarShip",
                column: "SpaceShipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StarShip",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "SpaceShipID",
                table: "StarShip");

            migrationBuilder.AddColumn<int>(
                name: "StarShipID",
                table: "StarShip",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidUntil",
                table: "ParkingSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarShip",
                table: "StarShip",
                column: "StarShipID");
        }
    }
}
