using System;
using System.Collections.Generic;
using BeComfy.Common.Types.Enums;

namespace BeComfy.Services.Flights.Dto
{
    public class FlightDto
    {
        public Guid Id { get; set; }
        public Guid StartAirport { get; set; }
        public IEnumerable<Guid> TransferAirports { get; set; }
        public IDictionary<SeatClass, int> AvailableSeats { get; set; }
        public Guid EndAirport { get; set; } 
        public string FlightType { get; set; }
        public decimal Price { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}