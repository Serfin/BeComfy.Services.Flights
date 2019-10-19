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
        public IDictionary<SeatClass, int> AvailableSeats { get; }
        public Guid StartAirport { get; }
        public IEnumerable<Guid> TransferAirports { get; }
        public Guid EndAirport { get; }
        public FlightType FlightType { get; }
        public decimal Price { get; }
        public DateTime FlightDate { get; }
        public DateTime? ReturnDate { get; }

        [JsonConstructor]
        public CreateFlight(Guid id, Guid planeId, IDictionary<SeatClass, int> availableSeats, 
            Guid startAirport, IEnumerable<Guid> transferAirports, Guid endAirport, 
            FlightType flightType, decimal price, DateTime flightDate, DateTime? returnDate)
        {
            Id = id;
            PlaneId = planeId;
            AvailableSeats = availableSeats;
            StartAirport = startAirport;
            TransferAirports = transferAirports;
            EndAirport = endAirport;
            FlightType = flightType;
            Price = price;
            FlightDate = flightDate;
            ReturnDate = returnDate;
        }
    }
}