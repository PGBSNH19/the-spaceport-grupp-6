﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class RevertedLatestTwoMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ParkingSpots_ParkingSpotID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSessions_ParkingSpots_ParkingSpotID",
                table: "ParkingSessions");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ParkingSpotID",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingSpotID",
                table: "ParkingSessions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParkingSpotID",
                table: "Invoices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSessions_ParkingSpots_ParkingSpotID",
                table: "ParkingSessions",
                column: "ParkingSpotID",
                principalTable: "ParkingSpots",
                principalColumn: "ParkingSpotID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSessions_ParkingSpots_ParkingSpotID",
                table: "ParkingSessions");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingSpotID",
                table: "ParkingSessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ParkingSpotID",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ParkingSpotID",
                table: "Invoices",
                column: "ParkingSpotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ParkingSpots_ParkingSpotID",
                table: "Invoices",
                column: "ParkingSpotID",
                principalTable: "ParkingSpots",
                principalColumn: "ParkingSpotID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSessions_ParkingSpots_ParkingSpotID",
                table: "ParkingSessions",
                column: "ParkingSpotID",
                principalTable: "ParkingSpots",
                principalColumn: "ParkingSpotID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
