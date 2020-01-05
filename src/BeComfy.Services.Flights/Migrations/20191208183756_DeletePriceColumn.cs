using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeComfy.Services.Flights.Migrations
{
    public partial class DeletePriceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Flights",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
