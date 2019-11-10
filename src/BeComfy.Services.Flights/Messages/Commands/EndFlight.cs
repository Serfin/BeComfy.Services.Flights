using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Flights.Messages.Commands
{
    public class EndFlight : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public EndFlight(Guid id)
        {
            Id = id;
        }
    }
}