using System;
using System.Collections.Generic;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Messages;
using BeComfy.Common.Types.Enums;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Events
{
    [MessageNamespace("tickets")]
    public class TicketBought : IEvent
    {
        public Guid Id { get; }
        public Guid FlightId { get; }
        public IDictionary<SeatClass, int> AvailableSeats { get; }
        
        [JsonConstructor]
        public TicketBought(Guid id, Guid flightId, IDictionary<SeatClass, int> availableSeats)
        {
            Id = id;
            FlightId = flightId;
            AvailableSeats = availableSeats;
        }
    }
}