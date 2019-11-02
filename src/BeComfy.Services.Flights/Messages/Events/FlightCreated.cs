using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Events
{
    public class FlightCreated : IEvent
    {
        public Guid Id { get; set; }

        [JsonConstructor]
        public FlightCreated(Guid id)
        {
            Id = id;
        }
    }
}