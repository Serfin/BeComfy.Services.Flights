using System;
using System.Collections.Generic;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Types.Enums;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Commands
{
    public class CreateFlight : ICommand
    {
        public Guid Id { get; }
        public int PlaneId { get; }
        public IDictionary<SeatClass, int> AvailableSeats { get; }
        public int StartAirport { get; }
        public IEnumerable<int> TransferAirports { get; }
        public int EndAirport { get; }
        public FlightType FlightType { get; }
        public DateTime FlightDate { get; }
        public DateTime ReturnDate { get; }

        [JsonConstructor]
        public CreateFlight(Guid id, int planeId, IDictionary<SeatClass, int> availableSeats,
            int startAirport, IEnumerable<int> transferAirports, int endAirport, 
            FlightType flightType, DateTime flightDate, DateTime returnDate)
        {
            Id = id;
            PlaneId = planeId;
            AvailableSeats = availableSeats;
            StartAirport = startAirport;
            TransferAirports = transferAirports;
            EndAirport = endAirport;
            FlightType = flightType;
            FlightDate = flightDate;
            ReturnDate = returnDate;
        }
    }
}