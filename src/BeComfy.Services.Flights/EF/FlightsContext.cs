using System;
using System.Collections.Generic;
using BeComfy.Common;
using BeComfy.Common.Types.Enums;
using BeComfy.Services.Flights.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.EF
{
    public class FlightsContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }

        public FlightsContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .Property(x => x.AvailableSeats)
                .HasConversion(
                    @in => JsonConvert.SerializeObject(@in), 
                    @out => JsonConvert.DeserializeObject<IDictionary<SeatClass, int>>(@out));

            modelBuilder.Entity<Flight>()
                .Property(x => x.TransferAirports)
                .HasConversion(
                    @in => JsonConvert.SerializeObject(@in), 
                    @out => JsonConvert.DeserializeObject<IEnumerable<Guid>>(@out));
        }
    }
}