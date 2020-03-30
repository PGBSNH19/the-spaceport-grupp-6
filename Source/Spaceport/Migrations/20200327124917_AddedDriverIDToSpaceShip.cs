using Microsoft.EntityFrameworkCore.Migrations;

namespace Spaceport.Migrations
{
    public partial class AddedDriverIDToSpaceShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShips_Persons_DriverPersonID",
                table: "SpaceShips");

            migrationBuilder.DropIndex(
                name: "IX_SpaceShips_DriverPersonID",
                table: "SpaceShips");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SpaceShips_DriverPersonID",
                table: "SpaceShips",
                column: "DriverPersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShips_Persons_DriverPersonID",
                table: "SpaceShips",
                column: "DriverPersonID",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
