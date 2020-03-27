using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class InvoiceHoldsRegistrationTimeFromParkingSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationTime",
                table: "ParkingSessions");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationTime",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PersonID",
                table: "Invoices",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Persons_PersonID",
                table: "Invoices",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Persons_PersonID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PersonID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RegistrationTime",
                table: "Invoices");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationTime",
                table: "ParkingSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
