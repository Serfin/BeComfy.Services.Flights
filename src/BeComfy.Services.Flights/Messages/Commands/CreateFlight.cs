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
        public Guid PlaneId { get; }
        public Guid StartAirport { get; }
        public IEnumerable<Guid> TransferAirports { get; }
        public Guid EndAirport { get; }
        public FlightType FlightType { get; }
        public DateTime FlightDate { get; }
        public DateTime ReturnDate { get; }

        [JsonConstructor]
        public CreateFlight(Guid id, Guid planeId, Guid startAirport, 
            IEnumerable<Guid> transferAirports, Guid endAirport, 
            FlightType flightType, DateTime flightDate, DateTime returnDate)
        {
            Id = id;
            PlaneId = planeId;
            StartAirport = startAirport;
            TransferAirports = transferAirports;
            EndAirport = endAirport;
            FlightType = flightType;
            FlightDate = flightDate;
            ReturnDate = returnDate;
        }
    }
}