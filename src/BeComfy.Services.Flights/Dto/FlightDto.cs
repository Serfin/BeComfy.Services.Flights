using System;
using System.Collections.Generic;
using BeComfy.Common.Types.Enums;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Dto
{
    public class FlightDto
    {
        public Guid Id { get; set; }
        public Guid StartAirport { get; set; }
        public IEnumerable<Guid> TransferAirports { get; set; }
        public Guid EndAirport { get; set; } 
        public IDictionary<SeatClass, int> AvailableSeats { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public FlightType FlightType { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}