using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ParkingSpot",
            //    columns: table => new
            //    {
            //        ParkingSpotID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MaxLength = table.Column<int>(nullable: false),
            //        SpacePortID = table.Column<int>(nullable: false),
            //        Occupied = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ParkingSpot", x => x.ParkingSpotID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Person",
            //    columns: table => new
            //    {
            //        PersonID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Person", x => x.PersonID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SpacePort",
            //    columns: table => new
            //    {
            //        SpacePortID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SpacePort", x => x.SpacePortID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SpaceShip",
            //    columns: table => new
            //    {
            //        SpaceShipID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DriverPersonID = table.Column<int>(nullable: true),
            //        Length = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SpaceShip", x => x.SpaceShipID);
            //        table.ForeignKey(
            //            name: "FK_SpaceShip_Person_DriverPersonID",
            //            column: x => x.DriverPersonID,
            //            principalTable: "Person",
            //            principalColumn: "PersonID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ParkingSession",
            //    columns: table => new
            //    {
            //        ParkingSessionID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ParkingSpotID = table.Column<int>(nullable: false),
            //        SpaceShipID = table.Column<int>(nullable: false),
            //        SpacePortID = table.Column<int>(nullable: false),
            //        ParkingToken = table.Column<bool>(nullable: false),
            //        RegistrationTime = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ParkingSession", x => x.ParkingSessionID);
            //        table.ForeignKey(
            //            name: "FK_ParkingSession_ParkingSpot_ParkingSpotID",
            //            column: x => x.ParkingSpotID,
            //            principalTable: "ParkingSpot",
            //            principalColumn: "ParkingSpotID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ParkingSession_SpacePort_SpacePortID",
            //            column: x => x.SpacePortID,
            //            principalTable: "SpacePort",
            //            principalColumn: "SpacePortID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ParkingSession_SpaceShip_SpaceShipID",
            //            column: x => x.SpaceShipID,
            //            principalTable: "SpaceShip",
            //            principalColumn: "SpaceShipID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ParkingSession_ParkingSpotID",
            //    table: "ParkingSession",
            //    column: "ParkingSpotID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ParkingSession_SpacePortID",
            //    table: "ParkingSession",
            //    column: "SpacePortID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ParkingSession_SpaceShipID",
            //    table: "ParkingSession",
            //    column: "SpaceShipID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SpaceShip_DriverPersonID",
            //    table: "SpaceShip",
            //    column: "DriverPersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSession");

            migrationBuilder.DropTable(
                name: "ParkingSpot");

            migrationBuilder.DropTable(
                name: "SpacePort");

            migrationBuilder.DropTable(
                name: "SpaceShip");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
