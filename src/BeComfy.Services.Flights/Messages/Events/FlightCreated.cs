using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Events
{
    public class FlightCreated : IEvent
    {
        public Guid Id { get; }
        public int AirplaneId { get; }
        public DateTime FlightStart { get; }
        public DateTime FlightEnd { get; }
        
        [JsonConstructor]
        public FlightCreated(Guid id, int airplaneId, 
            DateTime flightStart, DateTime flightEnd)
        {
            Id = id;
            AirplaneId = airplaneId;
            FlightStart = flightStart;
            FlightEnd = flightEnd;
        }
    }
}