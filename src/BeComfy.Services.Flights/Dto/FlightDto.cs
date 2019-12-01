using System;
using System.Collections.Generic;
using BeComfy.Common.Types.Enums;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Dto
{
    public class FlightDto
    {
        public Guid Id { get; set; }
        public int StartAirport { get; set; }
        public IEnumerable<int> TransferAirports { get; set; }
        public int EndAirport { get; set; } 
        public IDictionary<SeatClass, int> AvailableSeats { get; set; }
        public string FlightType { get; set; }
        public IEnumerable<Passenger> Passengers { get; set; }
        public decimal Price { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}