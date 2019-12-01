using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Events
{
    public class FlightEnded : IEvent
    {
        public int PlaneId { get; }
        
        [JsonConstructor]
        public FlightEnded(int planeId)
        {
            PlaneId = planeId;
        }
    }
}