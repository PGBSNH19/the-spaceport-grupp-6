using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class RenameInvoiceAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSessions_Invoices_InvoiceID",
                table: "ParkingSessions");

            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "ParkingSessions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountPaid",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSessions_Invoices_InvoiceID",
                table: "ParkingSessions",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSessions_Invoices_InvoiceID",
                table: "ParkingSessions");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "ParkingSessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AmountToPay",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSessions_Invoices_InvoiceID",
                table: "ParkingSessions",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
