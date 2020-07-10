using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Events
{
    public class FlightCreated : IEvent
    {
        public Guid FlightId { get; }
        public Guid AirplaneId { get; }
        public DateTime FlightStart { get; }
        public DateTime FlightEnd { get; }
        
        [JsonConstructor]
        public FlightCreated(Guid flightId, Guid airplaneId, 
            DateTime flightStart, DateTime flightEnd)
        {
            FlightId = flightId;
            AirplaneId = airplaneId;
            FlightStart = flightStart;
            FlightEnd = flightEnd;
        }
    }
}