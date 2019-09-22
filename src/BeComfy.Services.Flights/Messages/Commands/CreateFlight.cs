using System;
using System.Collections.Generic;
using BeComfy.Common.Messages;
using BeComfy.Common.Types.Enums;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Commands
{
    public class CreateFlight : ICommand
    {
        public Guid Id { get; set; }
        public Guid PlaneId { get; set; }
        public IDictionary<SeatClass, int> AvailableSeats { get; set; }
        public Guid StartAirport { get; set; }
        public Guid EndAirport { get; set; }
        public FlightType FlightType { get; set; }
        public decimal Price { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [JsonConstructor]
        public CreateFlight(Guid id, Guid planeId, IDictionary<SeatClass, int> availableSeats, Guid startAirport,
            Guid endAirport, FlightType flightType, decimal price, DateTime flightDate, DateTime? returnDate)
        {
            Id = id;
            PlaneId = planeId;
            AvailableSeats = availableSeats;
            StartAirport = startAirport;
            EndAirport = endAirport;
            FlightType = flightType;
            Price = price;
            FlightDate = flightDate;
            ReturnDate = returnDate;
        }
    }
}