using System;
using System.Collections.Generic;

namespace BeComfy.Services.Flights.Dto
{
    public class FlightDto
    {
        public Guid Id { get; set; }
        public Guid StartAirport { get; set; }
        public IEnumerable<Guid> TransferAirports { get; set; }
        public Guid EndAirport { get; set; } 
        public string FlightType { get; set; }
        public decimal Price { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}