using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportSimulatorBackend.Migrations
{
    public partial class DatabaseUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Runways");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Runways",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Runways");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Runways",
                type: "text",
                nullable: true);
        }
    }
}
