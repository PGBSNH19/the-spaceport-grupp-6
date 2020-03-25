using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class Invoice_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "ParkingSessions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paid = table.Column<bool>(nullable: false),
                    AmountToPay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSessions_InvoiceID",
                table: "ParkingSessions",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSessions_Invoices_InvoiceID",
                table: "ParkingSessions",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSessions_Invoices_InvoiceID",
                table: "ParkingSessions");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSessions_InvoiceID",
                table: "ParkingSessions");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "ParkingSessions");
        }
    }
}
