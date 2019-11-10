using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Events
{
    public class FlightEnded : IEvent
    {
        public Guid Id { get; }
        
        [JsonConstructor]
        public FlightEnded(Guid id)
        {
            Id = id;
        }
    }
}