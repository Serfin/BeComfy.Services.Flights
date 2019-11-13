using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Events
{
    public class FlightEnded : IEvent
    {
        public Guid PlaneId { get; }
        
        [JsonConstructor]
        public FlightEnded(Guid planeId)
        {
            PlaneId = planeId;
        }
    }
}