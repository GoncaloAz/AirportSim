using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportSimulatorBackend.Migrations
{
    public partial class DatabaseUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runways_Flights_flightOnRunwayId",
                table: "Runways");

            migrationBuilder.DropIndex(
                name: "IX_Runways_flightOnRunwayId",
                table: "Runways");

            migrationBuilder.DropColumn(
                name: "flightOnRunwayId",
                table: "Runways");

            migrationBuilder.AddColumn<string>(
                name: "flightOnRunway",
                table: "Runways",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flightOnRunway",
                table: "Runways");

            migrationBuilder.AddColumn<int>(
                name: "flightOnRunwayId",
                table: "Runways",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Runways_flightOnRunwayId",
                table: "Runways",
                column: "flightOnRunwayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Runways_Flights_flightOnRunwayId",
                table: "Runways",
                column: "flightOnRunwayId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
