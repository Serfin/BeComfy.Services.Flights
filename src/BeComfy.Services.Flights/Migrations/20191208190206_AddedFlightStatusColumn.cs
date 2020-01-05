using Microsoft.EntityFrameworkCore.Migrations;

namespace BeComfy.Services.Flights.Migrations
{
    public partial class AddedFlightStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightStatus",
                table: "Flights",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightStatus",
                table: "Flights");
        }
    }
}
