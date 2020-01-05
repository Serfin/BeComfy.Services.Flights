using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeComfy.Services.Flights.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlaneId = table.Column<Guid>(nullable: false),
                    AvailableSeats = table.Column<string>(nullable: true),
                    StartAirport = table.Column<Guid>(nullable: false),
                    TransferAirports = table.Column<string>(nullable: true),
                    EndAirport = table.Column<Guid>(nullable: false),
                    FlightType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    FlightDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
