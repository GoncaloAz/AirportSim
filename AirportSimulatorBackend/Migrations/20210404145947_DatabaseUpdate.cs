using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportSimulatorBackend.Migrations
{
    public partial class DatabaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "flightOnRunwayId",
                table: "Runways",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "Requests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "active",
                table: "Requests");
        }
    }
}
