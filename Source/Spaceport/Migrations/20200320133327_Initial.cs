using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Spaceports",
                columns: table => new
                {
                    SpacePortID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceports", x => x.SpacePortID);
                });

            migrationBuilder.CreateTable(
                name: "StarShip",
                columns: table => new
                {
                    StarShipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    DriverPersonID = table.Column<int>(nullable: true),
                    Length = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarShip", x => x.StarShipID);
                    table.ForeignKey(
                        name: "FK_StarShip_People_DriverPersonID",
                        column: x => x.DriverPersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    ParkingSpotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxLength = table.Column<int>(nullable: false),
                    SpacePortID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.ParkingSpotID);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_Spaceports_SpacePortID",
                        column: x => x.SpacePortID,
                        principalTable: "Spaceports",
                        principalColumn: "SpacePortID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSessions",
                columns: table => new
                {
                    ParkingSessionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingSpotID = table.Column<int>(nullable: true),
                    SpacePortID = table.Column<int>(nullable: true),
                    ParkingToken = table.Column<bool>(nullable: false),
                    RegistrationTime = table.Column<DateTime>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSessions", x => x.ParkingSessionID);
                    table.ForeignKey(
                        name: "FK_ParkingSessions_ParkingSpots_ParkingSpotID",
                        column: x => x.ParkingSpotID,
                        principalTable: "ParkingSpots",
                        principalColumn: "ParkingSpotID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingSessions_Spaceports_SpacePortID",
                        column: x => x.SpacePortID,
                        principalTable: "Spaceports",
                        principalColumn: "SpacePortID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSessions_ParkingSpotID",
                table: "ParkingSessions",
                column: "ParkingSpotID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSessions_SpacePortID",
                table: "ParkingSessions",
                column: "SpacePortID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_SpacePortID",
                table: "ParkingSpots",
                column: "SpacePortID");

            migrationBuilder.CreateIndex(
                name: "IX_StarShip_DriverPersonID",
                table: "StarShip",
                column: "DriverPersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSessions");

            migrationBuilder.DropTable(
                name: "StarShip");

            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Spaceports");
        }
    }
}
