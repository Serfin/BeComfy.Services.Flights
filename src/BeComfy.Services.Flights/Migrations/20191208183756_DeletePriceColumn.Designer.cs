﻿// <auto-generated />
using System;
using BeComfy.Services.Flights.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeComfy.Services.Flights.Migrations
{
    [DbContext(typeof(FlightsContext))]
    [Migration("20191208183756_DeletePriceColumn")]
    partial class DeletePriceColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeComfy.Services.Flights.Domain.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvailableSeats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EndAirport")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightType")
                        .HasColumnType("int");

                    b.Property<Guid>("PlaneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StartAirport")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransferAirports")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
