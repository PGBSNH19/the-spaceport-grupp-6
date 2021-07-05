using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class InvoiceHoldsPersonID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Invoices");
        }
    }
}
