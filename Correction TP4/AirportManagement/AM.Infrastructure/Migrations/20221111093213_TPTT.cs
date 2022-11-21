using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class TPTT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "Flights",
                newName: "PlaneFK");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                newName: "IX_Flights_PlaneFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFK",
                table: "Flights",
                column: "PlaneFK",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFK",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "PlaneFK",
                table: "Flights",
                newName: "PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneFK",
                table: "Flights",
                newName: "IX_Flights_PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId");
        }
    }
}
