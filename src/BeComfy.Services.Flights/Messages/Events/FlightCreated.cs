using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Events
{
    public class FlightCreated : IEvent
    {
        public Guid Id { get; set; }
        public DateTime FlightStart { get; set; }
        public DateTime FlightEnd { get; set; }
        
        [JsonConstructor]
        public FlightCreated(Guid id, DateTime flightStart, DateTime flightEnd)
        {
            Id = id;
            FlightStart = flightStart;
            FlightEnd = flightEnd;
        }
    }
}