using System;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Types.Enums;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Commands
{
    public class BookFlight : ICommand
    {
        public Guid FlightId { get; }
        public Guid UserId { get; }
        public SeatClass SeatClass { get; }

        [JsonConstructor]
        public BookFlight(Guid flightId, Guid userId, SeatClass seatClass)
        {
            FlightId = flightId;
            UserId = userId;
            SeatClass = seatClass;
        }
    }
}